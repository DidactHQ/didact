using DidactCore.Deployments;
using DidactCore.Environments;
using DidactCore.Flows;

namespace DidactEngine.Workers
{
    public sealed class WorkerContext
    {
        public FlowContext FlowContext { get; init; }

        public FlowRunContext FlowRunContext { get; init; }

        public DeploymentContext DeploymentContext { get; init; }

        public EnvironmentContext EnvironmentContext { get; init; }

        public IFlow? FlowInstance { get; set; }

        public WorkerContext(FlowContext flowContext, FlowRunContext flowRunContext,
            DeploymentContext deploymentContext, EnvironmentContext environmentContext, IFlow? flowInstance = null)
        {
            FlowContext = flowContext;
            FlowRunContext = flowRunContext;
            DeploymentContext = deploymentContext;
            EnvironmentContext = environmentContext;
            FlowInstance = flowInstance;
        }
    }
}
