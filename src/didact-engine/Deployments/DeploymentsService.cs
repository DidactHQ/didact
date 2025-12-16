using DidactCore.Deployments;

namespace DidactEngine.Deployments
{
    public class DeploymentsService
    {
        private readonly ILogger<DeploymentsService> _logger;

        public DeploymentsService(ILogger<DeploymentsService> logger)
        {
            _logger = logger;
        }

        public async Task FetchMissingDeploymentsAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }

        public async Task FetchDeploymentFromSourceAsync(IDeploymentContext deploymentContext, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}
