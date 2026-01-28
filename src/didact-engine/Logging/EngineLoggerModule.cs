using DidactEngine.Constants;
using DidactEngine.Modules;

namespace DidactEngine.Logging
{
    public class EngineLoggerModule : IModule
    {
        private readonly EngineLogChannel _engineChannel;

        public string Name => EngineConstants.ModuleNames.EngineLogger;

        public bool Enabled { get; set; } = true;

        public int Concurrency { get; set; } = 1;

        public int IntervalDelay { get; set; } = Defaults.DefaultModuleIntervalDelays.EngineLogger;

        public EngineLoggerModule(EngineLogChannel channel)
        {
            _engineChannel = channel;
        }

        public async Task ExecuteAsync(CancellationToken token)
        {
            await foreach (var log in _engineChannel.Channel.Reader.ReadAllAsync(token))
            {
                // TODO Implement Serilog or other logging utilities.
            }
        }
    }
}
