using System.Threading;

namespace DidactCore.Flows
{
    public class FlowExecutionContext : IFlowExecutionContext
    {
        public string? StringifiedJsonInput { get; set; }

        public CancellationToken CancellationToken { get; set; }

        public FlowExecutionContext(string? stringifiedJsonInput, CancellationToken cancellationToken)
        {
            StringifiedJsonInput = stringifiedJsonInput;
            CancellationToken = cancellationToken;
        }
    }
}
