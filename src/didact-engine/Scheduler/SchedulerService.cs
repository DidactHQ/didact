namespace DidactEngine.Scheduler
{
    public class SchedulerService
    {
        private readonly ILogger<SchedulerService> _logger;

        public SchedulerService(ILogger<SchedulerService> logger)
        {
            _logger = logger;
        }

        public async Task ScheduleAsync(CancellationToken cancellationToken)
        {
            // TODO Implement
            await Task.CompletedTask;
        }
    }
}
