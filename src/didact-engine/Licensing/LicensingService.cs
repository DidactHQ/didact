namespace DidactEngine.Licensing
{
    public class LicensingService
    {
        private readonly ILogger<LicensingService> _logger;

        public LicensingService(ILogger<LicensingService> logger)
        {
            _logger = logger;
        }
    }
}
