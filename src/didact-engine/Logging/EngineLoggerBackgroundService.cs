namespace DidactEngine.Logging
{
    public class EngineLoggerBackgroundService : BackgroundService
    {
        private readonly EngineLogChannel _engineChannel;
        private readonly IEngineLogRepository _repository;

        public EngineLoggerBackgroundService(EngineLogChannel channel, IEngineLogRepository repository)
        {
            _engineChannel = channel;
            _repository = repository;
        }

        protected override async Task ExecuteAsync(CancellationToken token)
        {
            await foreach (var log in _engineChannel.Channel.Reader.ReadAllAsync(token))
            {
                await _repository.InsertLogAsync(log, token);
            }
        }
    }
}
