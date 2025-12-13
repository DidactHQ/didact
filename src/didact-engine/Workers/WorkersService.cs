using DidactCore.Flows;
using DidactCore.Threading;
using DidactEngine.Constants;
using DidactEngine.Flows;
using DidactEngine.Logging;
using DidactEngine.Plugins;
using DidactServices.Flows;

namespace DidactEngine.Workers
{
    public class WorkersService
    {
        private readonly ILogger<WorkersService> _logger;
        private readonly TaskFactory _taskFactory;
        private readonly PluginsService _pluginsService;
        private readonly IFlowRunRepository _flowRunRepository;

        public int DequeueIntervalDelay { get; set; } = Defaults.DefaultWorkersServiceDequeueIntervalDelay;

        public WorkersService(ILogger<WorkersService> logger, DidactThreadpoolTaskScheduler taskScheduler, PluginsService pluginsService, IFlowRunRepository flowRunRepository)
        {
            _logger = logger;
            _taskFactory = new TaskFactory(taskScheduler);
            _pluginsService = pluginsService;
            _flowRunRepository = flowRunRepository;
        }

        private async Task<WorkerContext?> DequeueFlowRunAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }

        private async Task PollFlowRunCancellationAsync(WorkerContext workerContext, CancellationToken compositeCancellationToken)
        {
            while (true)
            {
                try
                {
                    compositeCancellationToken.ThrowIfCancellationRequested();
                    var isCancelled = await _flowRunRepository.CheckIfFlowRunIsCancelledAsync(workerContext.FlowRunContext.FlowRunId);
                    if (isCancelled)
                        return;
                    else
                        await Task.Delay(Defaults.FlowRunCancellationPollingInterval, compositeCancellationToken);
                }
                catch (OperationCanceledException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    _logger.LogError("FlowRun cancellation check failed for FlowRunId {flowRunId}. See inner exception: {ex}", workerContext.FlowRunContext.FlowRunId, ex);
                    await Task.Delay(Defaults.FlowRunCancellationPollingInterval, compositeCancellationToken);
                }
            }
        }

        private async Task ExecuteFlowRunTimeoutCountdownAsync(WorkerContext workerContext, CancellationToken compositeCancellationToken)
        {
            var timeout = TimeSpan.FromSeconds(workerContext.FlowRunContext.TimeoutSeconds);
            await Task.Delay(timeout, compositeCancellationToken);
        }

        private async Task ExecuteFlowRunAsync(WorkerContext workerContext, CancellationToken compositeCancellationToken)
        {
            if (workerContext.FlowInstance is null)
                throw new InvalidOperationException(
                    $"The {nameof(IFlow)} instance of {nameof(workerContext)} was null for FlowRunId {workerContext.FlowRunContext.FlowRunId}.");

            var flowExecutionContext = new FlowExecutionContext(workerContext.EnvironmentContext, workerContext.DeploymentContext,
                workerContext.FlowContext, workerContext.FlowRunContext, new FlowLogger(), compositeCancellationToken);

            await workerContext.FlowInstance.ExecuteAsync(flowExecutionContext);
        }

        private async Task ExecuteAsync(WorkerContext workerContext, CancellationToken cancellationToken)
        {
            using var flowRunCancellationTokenSource = new CancellationTokenSource();
            using var flowRunTimeoutCancellationTokenSource = new CancellationTokenSource();
            using var compositeCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, flowRunCancellationTokenSource.Token, flowRunTimeoutCancellationTokenSource.Token);
            var compositeCancellationToken = compositeCancellationTokenSource.Token;

            var flowRunExecutionTask = ExecuteFlowRunAsync(workerContext, compositeCancellationToken);
            var flowRunTimeoutTask = ExecuteFlowRunTimeoutCountdownAsync(workerContext, compositeCancellationToken);
            var flowRunCancellationCheckTask = PollFlowRunCancellationAsync(workerContext, compositeCancellationToken);

            Task completedTask;

            completedTask = await Task.WhenAny(flowRunExecutionTask, flowRunCancellationCheckTask, flowRunTimeoutTask);

            if (completedTask == flowRunExecutionTask)
            {
                // Cancel the other tasks.
                compositeCancellationTokenSource.Cancel();

                try
                {
                    await flowRunExecutionTask;

                    // If we get here, it completed successfully.
                    // TODO: mark as completed
                    // await _flowRunRepository.MarkFlowRunCompletedAsync(flowRunId);
                }
                catch (OperationCanceledException)
                {
                    // Flow threw OCE without timeout/DB-cancel winning the race.
                    // Treat this as a "self-cancelled" run.
                    // TODO: either CancelFlowRunAsync or a distinct "self cancelled" status
                    await _flowRunRepository.CancelFlowRunAsync(workerContext.FlowRunContext.FlowRunId);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "FlowRun {FlowRunId} failed with an unhandled exception.", workerContext.FlowRunContext.FlowRunId);

                    // TODO: retry logic / mark failed
                    // await _flowRunRepository.FailFlowRunAsync(flowRunId, ex);
                }
            }

            else if (completedTask == flowRunCancellationCheckTask)
            {
                // Issue cancellation.
                flowRunCancellationTokenSource.Cancel();

                try
                {
                    // Let the flow see the cancellation and stop.
                    await ExecuteTaskAndSwallowCancellationsAsync(flowRunExecutionTask);
                }
                catch (Exception)
                {
                    // Swallow any other exceptions that might bubble up because the flowrun cancellation happened first.
                }
            }

            else if (completedTask == flowRunTimeoutTask)
            {
                // Issue cancellation.
                flowRunTimeoutCancellationTokenSource.Cancel();

                try
                {
                    // Let the flow see the cancellation and stop.
                    await ExecuteTaskAndSwallowCancellationsAsync(flowRunExecutionTask);
                }
                catch (Exception)
                {
                    // Swallow any other exceptions that might bubble up because the flowrun timeout happened first.
                }

                // Mark the flowrun as timed out in the database.
                try
                {
                    await _flowRunRepository.TimeoutFlowRunAsync(workerContext.FlowRunContext.FlowRunId);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to mark FlowRun {FlowRunId} as timed out.", workerContext.FlowRunContext.FlowRunId);
                }
            }

            // Make sure the loser tasks are cleaned up.
            compositeCancellationTokenSource.Cancel();

            try
            {
                await Task.WhenAll(
                    ExecuteTaskAndSwallowCancellationsAsync(flowRunTimeoutTask),
                    ExecuteTaskAndSwallowCancellationsAsync(flowRunCancellationCheckTask)
                );
            }
            catch (Exception ex)
            {
                _logger.LogError("An unhandled exception occurred during worker task execution cleanup. See inner exception: {ex}", ex);
            }
        }

        private async Task ExecuteTaskAndSwallowCancellationsAsync(Task task)
        {
            try
            {
                await task;
            }
            catch (OperationCanceledException)
            {
                // Swallow cancellation.
            }
        }

        private async Task WorkAsync(CancellationToken cancellationToken)
        {
            /* Implementation
             * Step 1: Poll database for strictly-compatible flowruns (meaning the deployments are loaded as plugins already).
             * Step 2: Instantiate each flowrun.
             * Step 3: Execute each flowrun.
             */

            WorkerContext? workerContext = null;

            try
            {
                workerContext = await DequeueFlowRunAsync(cancellationToken);
            }
            catch (Exception ex)
            {

            }
            
            if (workerContext is null)
            {
                // If no work was found, delay to prevent hammering the database and early return.
                await Task.Delay(DequeueIntervalDelay, cancellationToken);
                return;
            }

            try
            {
                workerContext = _pluginsService.InstantiateFlow(workerContext);
            }
            catch (Exception ex)
            {

            }

            // Execute the flowrun.
            await ExecuteAsync(workerContext, cancellationToken);
        }

        public async Task WorkAsyncOnThreadpool(CancellationToken cancellationToken)
        {
            await _taskFactory.StartNew(async () => await WorkAsync(cancellationToken), cancellationToken).Unwrap();
        }
    }
}
