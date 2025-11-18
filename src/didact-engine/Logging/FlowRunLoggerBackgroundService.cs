namespace DidactEngine.Logging
{
    public class FlowRunLoggerBackgroundService : BackgroundService
    {
        private readonly FlowRunLogChannel _flowRunLogChannel;
        private readonly IFlowLogRepository _repository; // your DB writer abstraction

        public FlowRunLoggerBackgroundService(FlowRunLogChannel flowRunLogChannel, IFlowLogRepository repository)
        {
            _flowRunLogChannel = flowRunLogChannel;
            _repository = repository;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await foreach (var log in _flowRunLogChannel.Channel.Reader.ReadAllAsync(stoppingToken))
            {
                await _repository.InsertLogAsync(log, stoppingToken);
            }
        }
    }

}
