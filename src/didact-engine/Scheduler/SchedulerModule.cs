using DidactEngine.Constants;
using DidactEngine.Modules;

namespace DidactEngine.Scheduler
{
    public class SchedulerModule : IModule
    {
        private readonly SchedulerService _schedulerService;

        public string Name => EngineConstants.ModuleNames.Scheduler;

        public bool Enabled { get; set; } = true;

        public int Concurrency { get; set; } = 1;

        public int IntervalDelay { get; set; } = Defaults.DefaultModuleIntervalDelays.Scheduler;

        public SchedulerModule(SchedulerService schedulerService)
        {
            _schedulerService = schedulerService;
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            await _schedulerService.ScheduleAsync(cancellationToken);
        }
    }
}