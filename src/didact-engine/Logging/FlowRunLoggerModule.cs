using DidactEngine.Constants;
using DidactEngine.Engine;

namespace DidactEngine.Logging
{
    public class FlowRunLoggerModule : IEngineModule
    {
        private readonly FlowRunLogChannel _flowRunLogChannel;
        private readonly IFlowLogRepository _repository;

        public string Name => EngineConstants.EngineModuleNames.FlowRunLogger;
        public bool Enabled { get; set; } = true;

        public FlowRunLoggerModule(FlowRunLogChannel flowRunLogChannel, IFlowLogRepository repository)
        {
            _flowRunLogChannel = flowRunLogChannel;
            _repository = repository;
        }

        public async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await foreach (var log in _flowRunLogChannel.Channel.Reader.ReadAllAsync(stoppingToken))
            {
                await _repository.InsertLogAsync(log, stoppingToken);
            }
        }
    }

}
