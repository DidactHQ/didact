using Microsoft.Extensions.DependencyInjection;
using System;

namespace DidactCore.Plugins
{
    public interface IPluginDependencyInjector
    {
        /// <summary>
        /// The original <see cref="IServiceCollection"/> from Didact Engine.
        /// These services are automatically included in the <see cref="PluginServiceCollection"/>.
        /// </summary>
        IServiceCollection ApplicationServiceCollection { get; set; }

        /// <summary>
        /// The <see cref="IServiceCollection"/> that contains all of the services from both Didact Engine and the Flow Library.
        /// </summary>
        IServiceCollection PluginServiceCollection { get; set; }

        /// <summary>
        /// The corresponding <see cref="IServiceProvider"/> to the <see cref="PluginServiceCollection"/>.
        /// </summary>
        IServiceProvider PluginServiceProvider { get; set; }

        /// <summary>
        /// Clears the <see cref="PluginServiceCollection"/> and resets it to the <see cref="ApplicationServiceCollection"/>.
        /// </summary>
        void ResetServiceCollection();

        /// <summary>
        /// Adds each service from the plugin to the <see cref="PluginServiceCollection"/>
        /// and rebuilds the <see cref="PluginServiceProvider"/>.
        /// </summary>
        /// <param name="pluginServiceCollection"></param>
        void AddAndRebuildServiceCollection(IServiceCollection pluginServiceCollection);

        /// <summary>
        /// A wrapper function for the <see cref="ActivatorUtilities.CreateInstance{T}(IServiceProvider, object[])"/> method
        /// from the .NET dependency injection library that uses the <see cref="PluginServiceProvider"/>
        /// as the default <see cref="IServiceProvider"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters"></param>
        /// <returns></returns>
        T CreateInstance<T>(params object[] parameters);

        /// <summary>
        /// A wrapper function for the <see cref="ActivatorUtilities.CreateInstance(IServiceProvider, Type, object[])"/> method
        /// from the .NET dependency injection library that uses the <see cref="PluginServiceProvider"/>
        /// as the default <see cref="IServiceProvider"/>.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        object CreateInstance(Type type, params object[] parameters);
    }
}
