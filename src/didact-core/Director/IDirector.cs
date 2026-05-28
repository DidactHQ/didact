using DidactCore.Steps;
using System;
using System.Threading.Tasks;

namespace DidactCore.Director
{
    /// <summary>
    /// Utility service for dispatching actions against the Didact platform from within the context of a FlowRun.
    /// </summary>
    public interface IDirector
    {
        /// <summary>
        /// Creates a new FlowRun for the specified Flow to be linked as a child FlowRun.
        /// </summary>
        /// <param name="flowName">The name of the flow to create a subflow run for.</param>
        /// <param name="jsonPayload">The JSON payload to pass to the subflow run.</param>
        /// <param name="executeAt">The optional execution time for the subflow run.</param>
        Task CreateSubflowRunAsync(string flowName, string? jsonPayload, DateTime? executeAt);
        
        Task ExecuteStepAsync(string name, Func<IStepExecutionContext, Task> function);

        Task<TOutput> ExecuteStepAsync<TOutput>(string name, Func<IStepExecutionContext, Task<TOutput>> function);
    }
}
