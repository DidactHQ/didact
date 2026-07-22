using DidactEngine.Constants;
using DidactEngine.Modules;
using DidactEngine.Plugins;

namespace DidactEngine.Scheduler
{
    public sealed class SchedulerModule : PollingModule
    {
        private readonly SchedulerService _schedulerService;

        public SchedulerModule(SchedulerService schedulerService, ILogger<SchedulerModule> logger)
            : base(logger)
        {
            _schedulerService = schedulerService;
        }

        public override string Name => EngineConstants.ModuleNames.Scheduler;

        public override IReadOnlyCollection<Type> Dependencies => new[] { typeof(PluginsModule) };

        public override TimeSpan PollingInterval =>
            TimeSpan.FromMilliseconds(Defaults.DefaultModuleIntervalDelays.Scheduler);

        protected override Task PollAsync(CancellationToken cancellationToken)
        {
            return _schedulerService.ScheduleAsync(cancellationToken);
        }
    }
}
