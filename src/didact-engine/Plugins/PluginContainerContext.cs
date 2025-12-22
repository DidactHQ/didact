using DidactCore.Deployments;
using DidactCore.Environments;

namespace DidactEngine.Plugins
{
    public class PluginContainerContext : IPluginContainerContext
    {
        public IEnvironmentContext EnvironmentContext { get; set; }

        public IDeploymentContext DeploymentContext { get; set; }

        public PluginContainerContext(IEnvironmentContext environmentContext, IDeploymentContext deploymentContext)
        {
            EnvironmentContext = environmentContext;
            DeploymentContext = deploymentContext;
        }
    }
}
