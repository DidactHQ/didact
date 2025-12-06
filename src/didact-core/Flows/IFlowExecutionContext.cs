using DidactCore.Deployments;
using DidactCore.Environments;
using System.Threading;

namespace DidactCore.Flows
{
    public interface IFlowExecutionContext
    {
        CancellationToken CancellationToken { get; }

        IFlowLogger Logger { get; }

        EnvironmentContext EnvironmentContext { get; }

        DeploymentContext DeploymentContext { get; }

        FlowContext FlowContext { get; }

        FlowRunContext FlowRunContext { get; }
    }
}
