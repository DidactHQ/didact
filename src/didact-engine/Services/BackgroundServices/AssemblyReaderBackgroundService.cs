namespace DidactEngine.Services.BackgroundServices
{
    public class AssemblyReaderBackgroundService : BackgroundService
    {
        private readonly ILogger<AssemblyReaderBackgroundService> _logger;

        public AssemblyReaderBackgroundService(ILogger<AssemblyReaderBackgroundService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Starting {name}...", nameof(AssemblyReaderBackgroundService));

            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation("Ping from the {name}.", nameof(AssemblyReaderBackgroundService));
                    await Task.Delay(7000);
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical("{name} failed with the following exception:{nl}{exception}",
                    nameof(AssemblyReaderBackgroundService), Environment.NewLine, ex);
                throw;
            }
        }
    }
}
