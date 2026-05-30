using DidactCore.Deployments;
using DidactCore.Director;
using DidactCore.Environments;
using DidactCore.Steps;
using System.Collections.Generic;
using System.Threading;

namespace DidactCore.Flows
{
    public interface IFlowExecutionContext
    {
        CancellationToken CancellationToken { get; }

        IFlowLogger Logger { get; }

        IDirector Director { get; }

        IEnvironmentContext EnvironmentContext { get; }

        IDeploymentContext DeploymentContext { get; }

        IFlowContext FlowContext { get; }

        IFlowRunContext FlowRunContext { get; }

        ICollection<IStepContext> StepContexts { get; }
    }
}
