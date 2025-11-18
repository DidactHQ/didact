namespace DidactEngine.Logging
{
    public class EngineLogDto
    {
        public string LogLevel { get; set; } = null!;

        public string Message { get; set; } = null!;

        public DateTime Timestamp { get; set; }
    }
}
