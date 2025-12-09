namespace DidactEngine.Scheduler
{
    public class SchedulerService
    {
        private readonly ILogger<SchedulerService> _logger;

        public SchedulerService(ILogger<SchedulerService> logger)
        {
            _logger = logger;
        }
    }
}
