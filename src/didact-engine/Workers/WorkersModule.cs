using DidactEngine.Constants;
using DidactEngine.Modules;

namespace DidactEngine.Workers
{
    public class WorkersModule : IModule
    {
        private readonly WorkersService _workersService;

        public string Name => EngineConstants.ModuleNames.Workers;

        public bool Enabled { get; set; } = true;

        public int Concurrency { get; set; } = Environment.ProcessorCount;

        public int IntervalDelay { get; set; } = Defaults.DefaultModuleIntervalDelays.Workers;

        public WorkersModule(WorkersService workersService)
        {
            _workersService = workersService;
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            await _workersService.WorkAsyncOnThreadpool(cancellationToken);
        }
    }
}
