using DidactCore.Deployments;
using DidactCore.Environments;
using DidactCore.Flows;

namespace DidactEngine.Flows
{
    public class FlowConfigurationContext : IFlowConfigurationContext
    {
        public IEnvironmentContext EnvironmentContext { get; }

        public IDeploymentContext DeploymentContext { get; }

        public IFlowConfigurator Configurator { get; }

        public FlowConfigurationContext(IEnvironmentContext environmentContext,  IDeploymentContext deploymentContext,
            IFlowConfigurator configurator)
        {
            EnvironmentContext = environmentContext;
            DeploymentContext = deploymentContext;
            Configurator = configurator;
        }
    }
}
