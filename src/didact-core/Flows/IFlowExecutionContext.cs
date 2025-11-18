using System.Threading;

namespace DidactCore.Flows
{
    public interface IFlowExecutionContext
    {
        string? StringifiedJsonInput { get; }

        CancellationToken CancellationToken { get; }

        IFlowLogger Logger { get; }

        EnvironmentContext EnvironmentContext { get; }

        DeploymentContext DeploymentContext { get; }

        FlowContext FlowContext { get; }

        FlowRunContext FlowRunContext { get; }
    }
}
