namespace DidactEngine.Logging
{
    public class FlowRunLogDto
    {
        public string LogLevel { get; set; } = null!;

        public string Message { get; set; } = null!;

        public DateTime Timestamp { get; set; }
    }
}
