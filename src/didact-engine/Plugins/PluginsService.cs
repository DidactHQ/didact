using DidactServices.Workers;
using System.Collections.Concurrent;

namespace DidactEngine.Plugins
{
    public class PluginsService
    {
        private readonly ILogger<PluginsService> _logger;
        private readonly ConcurrentDictionary<long, PluginContainer> _pluginContainersDictionary;

        public PluginsService(ILogger<PluginsService> logger)
        {
            _logger = logger;
            _pluginContainersDictionary = new ConcurrentDictionary<long, PluginContainer>();
        }

        public async Task PollMissingDeploymentsAsync()
        {
            await Task.CompletedTask;
        }

        public async Task ShadowCopyDeploymentAsync()
        {
            await Task.CompletedTask;
        }

        public async Task LoadDeploymentAsPluginAsync()
        {
            await Task.CompletedTask;
        }

        public void ConfigurePluginDependencyInjection()
        {

        }

        public async Task ConfigureAllFlowsInPluginAsync()
        {
            await Task.CompletedTask;
        }

        public WorkerContext InstantiateFlow(IWorkerContext workerContext)
        {

        }
    }
}
