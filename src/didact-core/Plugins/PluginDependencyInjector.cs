using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;

namespace DidactCore.Plugins
{
    public class PluginDependencyInjector : IPluginDependencyInjector
    {
        public IServiceCollection ApplicationServiceCollection { get; set; }

        public IServiceCollection PluginServiceCollection { get; set; }

        public IServiceProvider PluginServiceProvider { get; set; }

        public PluginDependencyInjector(IServiceCollection applicationServiceCollection)
        {
            ApplicationServiceCollection = applicationServiceCollection;
            PluginServiceCollection = applicationServiceCollection;
            PluginServiceProvider = PluginServiceCollection.BuildServiceProvider();
        }

        public void ResetServiceCollection()
        {
            PluginServiceCollection.Clear();
            PluginServiceCollection = ApplicationServiceCollection;
        }

        public void AddAndRebuildServiceCollection(IServiceCollection pluginServiceCollection)
        {
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
