using DidactEngine.Constants;
using DidactEngine.Modules;

namespace DidactEngine.Logging
{
    public sealed class EngineLoggerModule : ILongRunningModule
    {
        private readonly EngineLogChannel _engineChannel;

        public EngineLoggerModule(EngineLogChannel channel)
        {
            _engineChannel = channel;
        }

        public string Name => EngineConstants.ModuleNames.EngineLogger;

        public bool Enabled { get; set; } = true;

        public IReadOnlyCollection<Type> Dependencies => Array.Empty<Type>();

        public async Task RunAsync(CancellationToken cancellationToken)
        {
            await foreach (var log in _engineChannel.Channel.Reader.ReadAllAsync(cancellationToken))
            {
                // TODO Implement Serilog or other logging utilities.
            }
        }
    }
}
