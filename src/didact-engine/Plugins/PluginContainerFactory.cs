using DidactEngine.Flows;

namespace DidactEngine.Plugins
{
    public class PluginContainerFactory : IPluginContainerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public PluginContainerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IPluginContainer Create(IPluginContainerContext context)
        {
            var logger = _serviceProvider.GetRequiredService<ILogger<IPluginContainer>>();
            var pluginAssemblyLoadContext = _serviceProvider.GetRequiredService<PluginAssemblyLoadContext>();
            var pluginDependencyInjector = _serviceProvider.GetRequiredService<IPluginDependencyInjector>();
            var flowRepository = _serviceProvider.GetRequiredService<IFlowRepository>();

            return new PluginContainer(logger, pluginDependencyInjector,
                pluginAssemblyLoadContext, flowRepository, context);
        }
    }
}
