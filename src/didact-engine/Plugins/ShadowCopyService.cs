namespace DidactEngine.Plugins
{
    public class ShadowCopyService
    {
        private readonly ILogger<ShadowCopyService> _logger;

        public ShadowCopyService(ILogger<ShadowCopyService> logger)
        {
            _logger = logger;
        }

        public async Task ShadowCopyDeployment(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}
