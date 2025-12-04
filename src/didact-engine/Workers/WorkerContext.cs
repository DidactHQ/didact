using DidactCore.Flows;

namespace DidactEngine.Workers
{
    public class WorkerContext
    {
        public FlowContext? FlowContext { get; set; }

        public FlowRunContext? FlowRunContext { get; set; }

        public EnvironmentContext? EnvironmentContext { get; set; }

        public DeploymentContext? DeploymentContext { get; set; }

        public IFlow? FlowInstance { get; set; }
    }
}
