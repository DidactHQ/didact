using DidactServices.Workers;
using System.Collections.Concurrent;

namespace DidactEngine.Plugins
{
    public class PluginsService
    {
        private readonly ILogger<PluginsService> _logger;
        private readonly IPluginContainerFactory _pluginContainerFactory;
        private readonly ConcurrentDictionary<long, IPluginContainer> _pluginContainersDictionary;

        public PluginsService(ILogger<PluginsService> logger, IPluginContainerFactory pluginContainerFactory)
        {
            _logger = logger;
            _pluginContainerFactory = pluginContainerFactory;
            _pluginContainersDictionary = new ConcurrentDictionary<long, IPluginContainer>();
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
            var pluginContainerContext = new PluginContainerContext();
            var pluginContainer = _pluginContainerFactory.Create(pluginContainerContext);
            await Task.CompletedTask;
        }

        public async Task ConfigurePluginAsync(IPluginContainer pluginContainer)
        {            
            // Step 1: Configure plugin DI.
            try
            {
                pluginContainer.ConfigureDependencyInjection();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "The plugin container failed to configure.");
            }

            // Step 2: Run plugin configurations for all flows.
            try
            {
                await pluginContainer.ConfigureFlowsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "The plugin container failed to configure.");
            }
        }

        public WorkerContext InstantiateFlow(IWorkerContext workerContext)
        {
            var flowName = workerContext.FlowContext.Name;
            var flowVersion = workerContext.FlowRunContext.FlowVersion;
        }
    }
}
