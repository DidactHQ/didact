using DidactCore.Deployments;
using DidactCore.Environments;
using DidactCore.Flows;
using Microsoft.Extensions.Logging;
using System.Threading;

namespace DidactCore.Steps
{
    public interface IStepExecutionContext
    {
        CancellationToken CancellationToken { get; }

        ILogger Logger { get; }

        IStepContext StepContext { get; }

        IEnvironmentContext EnvironmentContext { get; }

        IDeploymentContext DeploymentContext { get; }

        IFlowContext FlowContext { get; }

        IFlowRunContext FlowRunContext { get; }
    }
}
