using DidactEngine.Plugins;
using DidactEngine.System;

namespace DidactEngine.Engine
{
    public class EngineService : IEngineService, IDisposable
    {
        private ILogger<IEngineService> _logger;
        private readonly IPluginContainers _pluginContainers;
        private readonly CancellationTokenSource _cancellationTokenSource;
        private readonly SystemContext _systemContext;

        public EngineContext? EngineContext { get; private set; }

        public CancellationToken CancellationToken => _cancellationTokenSource.Token;

        public EngineService(ILogger<IEngineService> logger, IPluginContainers pluginContainers, SystemContext systemContext)
        {
            _logger = logger;
            _pluginContainers = pluginContainers;
            _cancellationTokenSource = new CancellationTokenSource();
            _systemContext = systemContext;
        }

        public async Task PollEngineShutdownAsync()
        {
            // TODO Implement
        }

        private void ShutdownEngine()
        {
            _logger.LogInformation("Shutting down the engine...");
            _cancellationTokenSource.Cancel();
        }

        public void Dispose() => _cancellationTokenSource.Dispose();
    }
}