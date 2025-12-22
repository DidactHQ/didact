using DidactCore.Deployments;
using DidactCore.Environments;

namespace DidactCore.Flows
{
    /// <summary>
    /// The context object passed to <see cref="IFlow"/> for metadata configuration.
    /// </summary>
    public interface IFlowConfigurationContext
    {
        IEnvironmentContext EnvironmentContext { get; }

        IDeploymentContext DeploymentContext { get; }

        IFlowConfigurator Configurator { get; }
    }
}
