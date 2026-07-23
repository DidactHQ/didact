using DidactEngine.Constants;
using DidactEngine.Logging;
using DidactEngine.Modules;
using DidactEngine.Plugins;

namespace DidactEngine.Workers
{
    public sealed class WorkersModule : ILongRunningModule
    {
        private readonly WorkersService _workersService;
        private readonly ILogger<WorkersModule> _logger;

        public WorkersModule(WorkersService workersService, ILogger<WorkersModule> logger)
        {
            _workersService = workersService;
            _logger = logger;
        }

        public string Name => EngineConstants.ModuleNames.Workers;

        public bool Enabled => true;

        public int WorkerCount { get; init; } = Environment.ProcessorCount;

        public IReadOnlyCollection<Type> Dependencies =>
            new[] { typeof(PluginsModule), typeof(FlowRunLoggerModule) };

        public async Task RunAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting {WorkerCount} worker loops.", WorkerCount);

            var workerTasks = Enumerable.Range(1, WorkerCount)
                .Select(workerIndex => RunWorkerAsync(workerIndex, cancellationToken))
                .ToArray();

            await Task.WhenAll(workerTasks);
        }

        private async Task RunWorkerAsync(int workerIndex, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Worker loop {WorkerIndex} started.", workerIndex);

            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        await _workersService.WorkAsyncOnThreadpool(cancellationToken);
                    }
                    catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
                    {
                        break;
                    }
                    catch (Exception exception)
                    {
                        _logger.LogError(exception, "Worker loop {WorkerIndex} failed during a work iteration. Retrying.", workerIndex);
                        await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
                    }
                }
            }
            finally
            {
                _logger.LogInformation("Worker loop {WorkerIndex} stopped.", workerIndex);
            }
        }
    }
}
