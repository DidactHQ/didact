using Microsoft.Extensions.DependencyInjection;

namespace DidactCore.Plugins
{
    public class ExamplePluginRegistrar : IPluginRegistrar
    {
        public ExamplePluginRegistrar() { }

        public IServiceCollection CreateServiceCollection()
        {
            IServiceCollection pluginServiceCollection = new ServiceCollection();

            // Register services for the Flow Library...
            // ...
            // ...

            return pluginServiceCollection;
        }
    }
}
