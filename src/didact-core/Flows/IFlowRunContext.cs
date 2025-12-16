namespace DidactCore.Flows
{
    public interface IFlowRunContext
    {
        public long FlowRunId { get; set; }

        public long FlowVersionId { get; set; }

        public string FlowVersion { get; set; }

        public string? JsonPayload { get; set; }

        public int TimeoutSeconds { get; set; }
    }
}
