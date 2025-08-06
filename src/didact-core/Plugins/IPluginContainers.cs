using System;
using System.Collections.Generic;

namespace DidactCore.Plugins
{
    public interface IPluginContainers
    {
        ICollection<IPluginContainer> PluginContainersCollection { get; set; }

        DateTime PluginContainersUpdatedAt { get; set; }

        void SetPluginContainersUpdatedAt(DateTime? pluginContainersUpdatedAt);

        /// <summary>
        /// Finds a matching <see cref="IPluginContainer"/> for the given <see cref="Type"/>.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="NoMatchedPluginException"></exception>
        /// <exception cref="MultipleMatchedPluginsException"></exception>
        IPluginContainer FindMatchingPluginContainer(Type type);

        /// <summary>
        /// Finds a matching <see cref="IPluginContainer"/> for the given <see cref="PluginAssemblyLoadContext"/>.
        /// </summary>
        /// <param name="pluginExecutionVersion"></param>
        /// <returns></returns>
        /// <exception cref="NoMatchedPluginException"></exception>
        IPluginContainer FindMatchingPluginContainer(PluginExecutionVersion pluginExecutionVersion);

        /// <summary>
        /// Finds a matching <see cref="IPluginContainer"/> for the given assembly FullName.
        /// </summary>
        /// <param name="assemblyFullName"></param>
        /// <returns></returns>
        /// <exception cref="NoMatchedPluginException"></exception>
        IPluginContainer FindMatchingPluginContainer(string assemblyName, string assemblyVersion);

        /// <summary>
        /// Finds a matching <see cref="IPluginContainer"/> for the given assembly FullName and type Name.
        /// </summary>
        /// <param name="assemblyFullName"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        /// <exception cref="NoMatchedPluginException"></exception>
        IPluginContainer FindMatchingPluginContainer(string assemblyName, string assemblyVersion, string typeName);

        void AddPluginContainer(IPluginContainer pluginContainer);

        void RemovePluginContainer(IPluginContainer pluginContainer);
    }
}
