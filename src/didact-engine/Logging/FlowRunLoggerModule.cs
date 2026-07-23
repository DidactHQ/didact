using DidactEngine.Constants;
using DidactEngine.Modules;

namespace DidactEngine.Logging
{
    public sealed class FlowRunLoggerModule : ILongRunningModule
    {
        private readonly FlowRunLogChannel _flowRunLogChannel;
        private readonly IFlowLogRepository _repository;

        public FlowRunLoggerModule(FlowRunLogChannel flowRunLogChannel, IFlowLogRepository repository)
        {
            _flowRunLogChannel = flowRunLogChannel;
            _repository = repository;
        }

        public string Name => EngineConstants.ModuleNames.FlowRunLogger;

        public bool Enabled => true;

        public IReadOnlyCollection<Type> Dependencies => Array.Empty<Type>();

        public async Task RunAsync(CancellationToken cancellationToken)
        {
            await foreach (var log in _flowRunLogChannel.Channel.Reader.ReadAllAsync(cancellationToken))
            {
                await _repository.InsertLogAsync(log, cancellationToken);
            }
        }
    }
}
