using DidactCore.Deployments;
using DidactCore.Environments;
using System.Threading;

namespace DidactCore.Flows
{
    public interface IFlowExecutionContext
    {
        CancellationToken CancellationToken { get; }

        IFlowLogger Logger { get; }

        IEnvironmentContext EnvironmentContext { get; }

        IDeploymentContext DeploymentContext { get; }

        IFlowContext FlowContext { get; }

        IFlowRunContext FlowRunContext { get; }
    }
}
