using DidactCore.Steps;
using System.Threading.Tasks;

namespace DidactDomain.Steps
{
    public interface IStepRepository
    {
        Task<IStepContext> GetStepAsync(long stepId);

        Task<IStepContext> GetOrCreateStepAsync(long flowRunId, string stepName);
    }
}
