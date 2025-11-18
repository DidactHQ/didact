using System.Threading.Channels;

namespace DidactEngine.Logging
{
    public class FlowRunLogChannel
    {
        private readonly Channel<FlowRunLogDto> _channel;

        public Channel<FlowRunLogDto> Channel => _channel;

        public FlowRunLogChannel()
        {
            _channel = System.Threading.Channels.Channel.CreateUnbounded<FlowRunLogDto>();
        }
    }
}
