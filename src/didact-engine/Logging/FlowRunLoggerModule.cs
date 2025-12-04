using DidactEngine.Constants;
using DidactEngine.Modules;

namespace DidactEngine.Logging
{
    public class FlowRunLoggerModule : IModule
    {
        private readonly FlowRunLogChannel _flowRunLogChannel;
        private readonly IFlowLogRepository _repository;

        public string Name => EngineConstants.ModuleNames.FlowRunLogger;

        public bool Enabled { get; set; } = true;

        public int Concurrency { get; set; } = 1;

        public int IntervalDelay { get; set; } = Defaults.DefaultModuleIntervalDelays.FlowRunLogger;

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
