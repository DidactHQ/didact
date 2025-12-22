using DidactCore.Deployments;
using DidactCore.Environments;

namespace DidactEngine.Plugins
{
    public interface IPluginContainerContext
    {
        IEnvironmentContext EnvironmentContext { get; }

        IDeploymentContext DeploymentContext { get; }
    }
}
