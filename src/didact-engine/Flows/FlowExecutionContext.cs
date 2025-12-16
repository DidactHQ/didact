using DidactCore.Deployments;
using DidactCore.Environments;
using DidactCore.Flows;

namespace DidactEngine.Flows
{
    public class FlowExecutionContext : IFlowExecutionContext
    {
        public CancellationToken CancellationToken { get; }

        public IFlowLogger Logger { get; }

        public IEnvironmentContext EnvironmentContext { get; }

        public IDeploymentContext DeploymentContext { get; }

        public IFlowContext FlowContext { get; }

        public IFlowRunContext FlowRunContext { get; }

        public FlowExecutionContext(IEnvironmentContext environmentContext, IDeploymentContext deploymentContext,
            IFlowContext flowContext, IFlowRunContext flowRunContext, IFlowLogger flowLogger, CancellationToken cancellationToken)
        {
            EnvironmentContext = environmentContext;
            DeploymentContext = deploymentContext;
            FlowContext = flowContext;
            FlowRunContext = flowRunContext;
            Logger = flowLogger;
            CancellationToken = cancellationToken;
        }
    }
}
