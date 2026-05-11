using System;
using System.Threading.Tasks;

namespace DidactCore.Flows
{
    public interface IDirector
    {
        Task EnqueueFlowRunAsync(string flowName, string? jsonPayload = null);

        Task EnqueueFlowRunAsync(string flowName, string? jsonPayload = null, DateTime? executeAt  = null);
    }
}
