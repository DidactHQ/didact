using System.Threading;
using System.Threading.Tasks;

namespace DidactCore.Flows
{
    public interface IFlowExecutor
    {
        /// <summary>
        /// Asynchronously retrieves the next available FlowRun from persistent storage.
        /// </summary>
        /// <returns></returns>
        Task<FlowRunDto> FetchFlowRunAsync();

        /// <summary>
        /// Identifies a compatible plugin to instantiate a FlowRun by its Type using the plugin's dependency injection system
        /// and converts it to an <see cref="IFlow"/> instance.
        /// </summary>
        /// <param name="flowRunDto"></param>
        /// <returns></returns>
        Task<FlowRunDto> CreateFlowInstanceAsync(FlowRunDto flowRunDto);

        /// <summary>
        /// Asynchronously checks if the FlowRun was cancelled from persistent storage in a loop.
        /// </summary>
        /// <param name="flowRunId"></param>
        /// <param name="compositeCancellationToken"></param>
        /// <returns></returns>
        Task CheckForFlowRunCancellationAsync(long flowRunId, CancellationToken compositeCancellationToken);

        /// <summary>
        /// Asynchronously executes a <see cref="Task"/> countdown whose completion represents when the FlowRun is supposed to timeout.
        /// </summary>
        /// <param name="flowRunTimeoutSeconds"></param>
        /// <param name="compositeCancellationToken"></param>
        /// <returns></returns>
        Task ExecuteFlowRunTimeoutCountdownAsync(int flowRunTimeoutSeconds, CancellationToken compositeCancellationToken);

        /// <summary>
        /// Asynchronously executes the FlowRun by running its <see cref="IFlow.ExecuteAsync"/> method.
        /// </summary>
        /// <param name="flowRunDto"></param>
        /// <param name="compositeCancellationToken"></param>
        /// <returns></returns>
        Task ExecuteFlowRunAsync(FlowRunDto flowRunDto, CancellationToken compositeCancellationToken);

        /// <summary>
        /// Asynchronously executes the FlowRun and initializes its cancellation checks and countdown <see cref="Task"/>.
        /// Intelligently handles cancellation from an engine shutdown, FlowRun cancellation, or FlowRun timeout.
        /// </summary>
        /// <param name="flowRunDto"></param>
        /// <returns></returns>
        Task ExecuteIntelligentAsync(FlowRunDto flowRunDto);
    }
}
