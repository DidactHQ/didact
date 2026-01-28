namespace DidactEngine.Logging
{
    public class EngineLogger : ILogger
    {
        private readonly string _category;
        private readonly EngineLogChannel _channel;

        public EngineLogger(string category, EngineLogChannel channel)
        {
            _category = category;
            _channel = channel;
        }

        public IDisposable BeginScope<TState>(TState state) where TState : notnull => default!;
        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception? exception,
            Func<TState, Exception?, string> formatter)
        {
            var msg = new EngineLogMessage(
                Timestamp: DateTimeOffset.UtcNow,
                Level: logLevel,
                Category: _category,
                Message: formatter(state, exception)
            );

            _channel.Channel.Writer.TryWrite(msg);
        }
    }
}
