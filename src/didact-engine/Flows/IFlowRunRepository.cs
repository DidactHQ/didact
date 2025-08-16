using DidactCore.Entities;
using System.Threading.Tasks;

namespace DidactCore.Flows
{
    public interface IFlowRunRepository
    {
        Task<FlowRun> GetFlowRunAsync(long flowRunId);

        Task<FlowRun> GetFlowRunByNameAsync(string name);

        Task<FlowRun> GetFlowRunByDescriptionAsync(string description);

        Task<FlowRun> CreateAndEnqueueFlowRunAsync(FlowRun flowRun);

        Task<FlowRun> CreateAndExecuteFlowRunAsync(FlowRun flowRun);

        Task<FlowRun> UpdateFlowRunAsync(long flowRunId, FlowRun flowRun);

        Task DeleteFlowRunAsync(long flowRunId);

        Task<bool> CheckIfFlowRunIsCancelledAsync(long flowRunId);

        Task CancelFlowRunAsync(long flowRunId);

        Task TimeoutFlowRunAsync(long flowRunId);

        Task FailFlowRunAsync(long flowRunId);
    }
}
