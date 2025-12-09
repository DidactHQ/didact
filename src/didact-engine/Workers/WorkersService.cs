using DidactCore.Threading;
using DidactEngine.Constants;

namespace DidactEngine.Workers
{
    public class WorkersService
    {
        private readonly ILogger<WorkersService> _logger;
        private readonly TaskFactory _taskFactory;

        public int DequeueIntervalDelay { get; set; } = Defaults.DefaultWorkersServiceDequeueIntervalDelay;

        public WorkersService(ILogger<WorkersService> logger, DidactThreadpoolTaskScheduler taskScheduler)
        {
            _logger = logger;
            _taskFactory = new TaskFactory(taskScheduler);
        }

        private async Task<WorkerContext?> DequeueFlowRunAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }

        private async Task<WorkerContext> InstantiateFlowAsync(WorkerContext workerContext, CancellationToken cancellationToken)
        {

        }

        private async Task PollFlowRunCancellationAsync(WorkerContext workerContext, CancellationToken compositeCancellationToken)
        {

        }

        private async Task ExecuteFlowRunTimeoutCountdownAsync(WorkerContext workerContext, CancellationToken compositeCancellationToken)
        {

        }

        private async Task ExecuteFlowRunAsync(WorkerContext workerContext, CancellationToken compositeCancellationToken)
        {

        }

        private async Task ExecuteAsync(WorkerContext workerContext, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }

        public async Task DequeueAndExecuteAsync(CancellationToken cancellationToken)
        {
            /* Implementation
             * Step 1: Poll database for strictly-compatible flowruns (meaning the deployments are loaded as plugins already).
             * Step 2: Instantiate each flowrun.
             * Step 3: Execute each flowrun.
             */

            await _taskFactory.StartNew(async () =>
            {
                // Poll database for strictly-compatible flowruns (meaning the deployments are loaded as plugins already).
                var workerContext = await DequeueFlowRunAsync(cancellationToken);
                if (workerContext is null)
                {
                    await Task.Delay(DequeueIntervalDelay, cancellationToken);
                    return;
                }

                // Instantiate the flowrun.
                workerContext = await InstantiateFlowAsync(workerContext, cancellationToken);

                // Execute the flowrun.
                await ExecuteAsync(workerContext, cancellationToken);
            }, cancellationToken).Unwrap();
        }
    }
}
