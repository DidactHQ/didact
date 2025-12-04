using DidactEngine.Plugins;
using DidactEngine.System;

namespace DidactEngine.Engine
{
    public class EngineService : IEngineService
    {
        private ILogger<IEngineService> _logger;
        private readonly IPluginContainers _pluginContainers;
        private readonly SystemContext _systemContext;

        public EngineContext? EngineContext { get; private set; }

        public CancellationToken CancellationToken { get; private set; }

        public EngineService(ILogger<IEngineService> logger, IPluginContainers pluginContainers, SystemContext systemContext)
        {
            _logger = logger;
            CancellationToken = new CancellationTokenSource().Token;
            _pluginContainers = pluginContainers;
            _systemContext = systemContext;
        }

        public async Task PollEngineShutdownAsync()
        {
            // TODO Implement
        }
    }
}
