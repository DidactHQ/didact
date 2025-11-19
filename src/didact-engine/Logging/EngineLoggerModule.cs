using DidactEngine.Constants;
using DidactEngine.Engine;

namespace DidactEngine.Logging
{
    public class EngineLoggerModule : IEngineModule
    {
        private readonly EngineLogChannel _engineChannel;
        private readonly IEngineLogRepository _repository;

        public string Name => EngineConstants.EngineModuleNames.EngineLogger;
        public bool Enabled { get; set; } = true;

        public EngineLoggerModule(EngineLogChannel channel, IEngineLogRepository repository)
        {
            _engineChannel = channel;
            _repository = repository;
        }

        public async Task ExecuteAsync(CancellationToken token)
        {
            await foreach (var log in _engineChannel.Channel.Reader.ReadAllAsync(token))
            {
                await _repository.InsertLogAsync(log, token);
            }
        }
    }
}
