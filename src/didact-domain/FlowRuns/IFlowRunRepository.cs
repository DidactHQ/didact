using DidactCore.Flows;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DidactDomain.FlowRuns
{
    public interface IFlowRunRepository
    {
        Task<FlowRunWorkerContextDto> DequeueFlowRunWithWorkerContextAsync(CancellationToken cancellationToken);

        Task<IFlowRunContext> GetFlowRunAsync(long flowRunId);

        Task<IFlowRunContext> CreateFlowRunAsync(string flowName, string? jsonPayload, DateTime? executeAt);

        Task<IFlowRunContext> CreateSubflowRunAsync(string flowName, string? jsonPayload, DateTime? executeAt);

        Task<IFlowRunContext> TransitionFlowRunStateAsync(long flowRunId, string flowRunStateName);

        Task DeleteFlowRunAsync(long flowRunId);

        Task<bool> CheckIfFlowRunIsCancelledAsync(long flowRunId);

        Task CancelFlowRunAsync(long flowRunId);

        Task TimeoutFlowRunAsync(long flowRunId);

        Task FailFlowRunAsync(long flowRunId);

        Task CompleteFlowRunAsync(long flowRunId);
    }
}
