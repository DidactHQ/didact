using Microsoft.Extensions.DependencyInjection;

namespace DidactCore.Plugins
{
    public interface IPluginRegistrar
    {
        /// <summary>
        /// Creates a new <see cref="IServiceCollection"/> containing all dependencies self-registered in the plugin.
        /// </summary>
        /// <returns></returns>
        IServiceCollection CreateServiceCollection();
    }
}
