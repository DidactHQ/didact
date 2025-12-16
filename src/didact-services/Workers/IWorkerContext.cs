using DidactCore.Deployments;
using DidactCore.Environments;
using DidactCore.Flows;

namespace DidactServices.Workers
{
    public interface IWorkerContext
    {
        public IFlowContext FlowContext { get; init; }

        public IFlowRunContext FlowRunContext { get; init; }

        public IDeploymentContext DeploymentContext { get; init; }

        public IEnvironmentContext EnvironmentContext { get; init; }

        public IFlow? FlowInstance { get; set; }
    }
}
