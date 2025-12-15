using DidactCore.Deployments;
using DidactCore.Environments;

namespace DidactCore.Flows
{
    public interface IFlowConfigurationContext
    {
        EnvironmentContext EnvironmentContext { get; }

        DeploymentContext DeploymentContext { get; }

        IFlowConfigurator Configurator { get; }
    }
}
