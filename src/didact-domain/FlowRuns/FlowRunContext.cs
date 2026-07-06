using DidactCore.Flows;

namespace DidactDomain.FlowRuns
{
    public class FlowRunContext : IFlowRunContext
    {
        public long FlowRunId { get; set; }

        public long FlowVersionId { get; set; }

        public string FlowVersion { get; set; } = null!;

        public string? JsonPayload { get; set; }

        public int TimeoutSeconds { get; set; }
    }
}
