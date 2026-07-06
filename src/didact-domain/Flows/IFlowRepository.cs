using DidactCore.Flows;
using System.Threading.Tasks;

namespace DidactDomain.Flows
{
    public interface IFlowRepository
    {
        Task<IFlowContext> GetFlowAsync(long flowId);

        Task<IFlowContext> GetFlowAsync(string flowName, string environmentName);

        Task DeactivateFlowAsync(long flowId);
    }
}
