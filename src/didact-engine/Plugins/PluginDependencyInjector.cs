using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DidactEngine.Plugins
{
    public class PluginDependencyInjector : IPluginDependencyInjector
    {
        private readonly IServiceCollection _applicationServiceCollection;

        public IServiceCollection PluginServiceCollection { get; set; }

        public IServiceProvider PluginServiceProvider { get; set; }

        public PluginDependencyInjector(IServiceCollection applicationServiceCollection)
        {
            _applicationServiceCollection = applicationServiceCollection;
            PluginServiceCollection = new ServiceCollection();
            PluginServiceProvider = PluginServiceCollection.BuildServiceProvider();
        }

        public void ClearServiceCollection()
        {
            PluginServiceCollection.Clear();
        }

        public void BuildServiceCollection(IServiceCollection pluginServiceCollection)
        {
            foreach (var service in _applicationServiceCollection)
            {
                PluginServiceCollection.TryAdd(service);
            }

            foreach (var service in pluginServiceCollection)
            {
                PluginServiceCollection.TryAdd(service);
            }

            PluginServiceProvider = PluginServiceCollection.BuildServiceProvider();
        }

        public T CreateInstance<T>(params object[] parameters)
        {
            return ActivatorUtilities.CreateInstance<T>(PluginServiceProvider, parameters);
        }

        public object CreateInstance(Type type, params object[] parameters)
        {
            return ActivatorUtilities.CreateInstance(PluginServiceProvider, type, parameters);
        }
    }
}
