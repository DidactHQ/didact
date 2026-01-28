using System.Threading;
using System.Threading.Tasks;

namespace DidactServices.FlowRuns
{
    public interface IFlowRunRepository
    {
        Task<FlowRunWorkerContextDto> DequeueFlowRunWithWorkerContextAsync(CancellationToken cancellationToken);

        Task<FlowRun> GetFlowRunAsync(long flowRunId);

        Task<FlowRun> GetFlowRunByNameAsync(string name);

        Task<FlowRun> CreateAndEnqueueFlowRunAsync(FlowRun flowRun);

        Task<FlowRun> CreateAndExecuteFlowRunAsync(FlowRun flowRun);

        Task DeleteFlowRunAsync(long flowRunId);

        Task<bool> CheckIfFlowRunIsCancelledAsync(long flowRunId);

        Task CancelFlowRunAsync(long flowRunId);

        Task TimeoutFlowRunAsync(long flowRunId);

        Task FailFlowRunAsync(long flowRunId);

        Task CompleteFlowRunAsync(long flowRunId);
    }
}
