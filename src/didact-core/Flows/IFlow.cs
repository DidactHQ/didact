using System.Threading.Tasks;

namespace DidactCore.Flows
{
    public interface IFlow
    {
        /// <summary>
        /// Asynchronously configures the Flow metadata as a returned <see cref="IFlowConfigurator"/>.
        /// </summary>
        /// <param name="flowConfigurator"></param>
        /// <returns></returns>
        Task<IFlowConfigurator> ConfigureAsync(IFlowConfigurator flowConfigurator);

        /// <summary>
        /// Asynchronously executes the Flow.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        Task ExecuteAsync(IFlowExecutionContext context);
    }
}
