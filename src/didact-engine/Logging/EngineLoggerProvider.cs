namespace DidactEngine.Logging
{
    public class EngineLoggerProvider : ILoggerProvider
    {
        private readonly EngineLogChannel _channel;

        public EngineLoggerProvider(EngineLogChannel channel)
        {
            _channel = channel;
        }

        public ILogger CreateLogger(string categoryName)
            => new EngineLogger(categoryName, _channel);

        public void Dispose() { }
    }
}
