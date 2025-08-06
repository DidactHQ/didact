namespace DidactEngine.Services.BackgroundServices
{
    public class SchedulerBackgroundService : BackgroundService
    {
        private readonly ILogger<SchedulerBackgroundService> _logger;

        public SchedulerBackgroundService(ILogger<SchedulerBackgroundService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Starting {name}...", nameof(SchedulerBackgroundService));

            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation("Ping from the {name}.", nameof(SchedulerBackgroundService));
                    await Task.Delay(5000);
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical("{name} failed with the following exception:{nl}{exception}",
                    nameof(SchedulerBackgroundService), Environment.NewLine, ex);
                throw;
            }
        }
    }
}
