using System.Threading.Channels;

namespace DidactEngine.Logging
{
    public class EngineLogChannel
    {
        private readonly Channel<EngineLogDto> _channel;

        public Channel<EngineLogDto> Channel => _channel;

        public EngineLogChannel()
        {
            _channel = System.Threading.Channels.Channel.CreateUnbounded<EngineLogDto>();
        }
    }
}
