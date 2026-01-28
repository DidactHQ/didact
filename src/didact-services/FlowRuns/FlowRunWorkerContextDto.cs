namespace DidactServices.FlowRuns
{
    public class FlowRunWorkerContextDto
    {
        public long FlowRunId { get; set; }

        public long FlowVersionId { get; set; }

        public string FlowVersion { get; set; } = null!;

        public string? JsonPayload { get; set; }

        public int TimeoutSeconds { get; set; }
    }
}
