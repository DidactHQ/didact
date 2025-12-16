using DidactCore.Deployments;
using DidactCore.Environments;

namespace DidactCore.Flows
{
    public interface IFlowConfigurationContext
    {
        IEnvironmentContext EnvironmentContext { get; }

        IDeploymentContext DeploymentContext { get; }

        IFlowConfigurator Configurator { get; }
    }
}
