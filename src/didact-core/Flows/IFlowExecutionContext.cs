using System.Threading;

namespace DidactCore.Flows
{
    public interface IFlowExecutionContext
    {
        string? StringifiedJsonInput { get; set; }

        CancellationToken CancellationToken { get; set; }
    }
}
