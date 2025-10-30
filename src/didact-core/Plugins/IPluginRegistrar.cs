using Microsoft.Extensions.DependencyInjection;

namespace DidactCore.Plugins
{
    public interface IPluginRegistrar
    {
        /// <summary>
        /// Registers plugin dependencies to be used in plugin-isolated dependency injection.
        /// </summary>
        /// <returns></returns>
        IServiceCollection RegisterServices(IServiceCollection pluginServiceCollection);
    }
}
