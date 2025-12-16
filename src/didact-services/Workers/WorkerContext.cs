using DidactCore.Deployments;
using DidactCore.Environments;
using DidactCore.Flows;

namespace DidactServices.Workers
{
    public class WorkerContext : IWorkerContext
    {
        public IFlowContext FlowContext { get; init; }

        public IFlowRunContext FlowRunContext { get; init; }

        public IDeploymentContext DeploymentContext { get; init; }

        public IEnvironmentContext EnvironmentContext { get; init; }

        public IFlow? FlowInstance { get; set; }

        public WorkerContext(IFlowContext flowContext, IFlowRunContext flowRunContext,
            IDeploymentContext deploymentContext, IEnvironmentContext environmentContext, IFlow? flowInstance = null)
        {
            FlowContext = flowContext;
            FlowRunContext = flowRunContext;
            DeploymentContext = deploymentContext;
            EnvironmentContext = environmentContext;
            FlowInstance = flowInstance;
        }
    }
}
