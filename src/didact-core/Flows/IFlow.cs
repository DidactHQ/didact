using System.Threading.Tasks;

namespace DidactCore.Flows
{
    public interface IFlow
    {
        /// <summary>
        /// Asynchronously configures the Flow metadata.
        /// </summary>
        /// <param name="flowConfigurator"></param>
        /// <returns></returns>
        Task<IFlowConfigurationContext> ConfigureAsync(IFlowConfigurationContext context);

        /// <summary>
        /// Asynchronously executes the Flow.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        Task ExecuteAsync(IFlowExecutionContext context);
    }
}
