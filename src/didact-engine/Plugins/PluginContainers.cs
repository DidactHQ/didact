using System;
using System.Collections.Generic;
using System.Linq;

namespace DidactCore.Plugins
{
    public class PluginContainers : IPluginContainers
    {
        public ICollection<IPluginContainer> PluginContainersCollection { get; set; } = [];

        public DateTime PluginContainersUpdatedAt { get; set; }

        public PluginContainers() { }

        public void SetPluginContainersUpdatedAt(DateTime? pluginContainersUpdatedAt) =>
            PluginContainersUpdatedAt = pluginContainersUpdatedAt ?? DateTime.UtcNow;

        public IPluginContainer FindMatchingPluginContainer(Type type)
        {
            var assemblyFullName = type.Assembly.FullName;
            var matchingPluginContainers = PluginContainersCollection.Select(s => s)
                .Where(p => p.PluginAssemblyLoadContext.Assemblies.Select(a => a.FullName).Contains(assemblyFullName)
                    && p.PluginAssemblyLoadContext.Assemblies.SelectMany(s => s.GetTypes()).Contains(type))
                .ToList();

            if (matchingPluginContainers.Count == 0)
            {
                throw new NoMatchedPluginException();
            }
            if (matchingPluginContainers.Count > 1)
            {
                throw new MultipleMatchedPluginsException();
            }

            return matchingPluginContainers.First();
        }

        public IPluginContainer FindMatchingPluginContainer(PluginExecutionVersion pluginExecutionVersion)
        {
            var matchingPluginContainers = PluginContainersCollection.Select(s => s)
                .Where(p => p.PluginExecutionVersions.Contains(pluginExecutionVersion))
                .ToList();

            if (matchingPluginContainers.Count == 0)
            {
                throw new NoMatchedPluginException();
            }

            if (matchingPluginContainers.Count > 1)
            {
                return matchingPluginContainers.OrderByDescending(p => p.PluginLoadedAt).First();
            }

            return matchingPluginContainers.First();
        }

        public IPluginContainer FindMatchingPluginContainer(string assemblyName, string assemblyVersion)
        {
            var matchingPluginContainers = PluginContainersCollection.Select(s => s)
                .Where(p => p.PluginAssemblyLoadContext.Assemblies.Select(a => a.GetName().Name).Contains(assemblyName)
                    && p.PluginAssemblyLoadContext.Assemblies.Select(a => a.GetName().Version?.ToString() ?? string.Empty).Contains(assemblyVersion))
                .ToList();

            if (matchingPluginContainers.Count == 0)
            {
                throw new NoMatchedPluginException();
            }
            if (matchingPluginContainers.Count > 1)
            {
                return matchingPluginContainers.OrderByDescending(p => p.PluginLoadedAt).First();
            }

            return matchingPluginContainers.First();
        }

        public IPluginContainer FindMatchingPluginContainer(string assemblyName, string assemblyVersion, string typeName)
        {
            var matchingPluginContainers = PluginContainersCollection.Select(s => s)
                .Where(p => p.PluginAssemblyLoadContext.Assemblies.Select(a => a.FullName).Contains(assemblyName)
                    && p.PluginAssemblyLoadContext.Assemblies.Select(a => a.GetName().Version?.ToString() ?? string.Empty).Contains(assemblyVersion)
                    && p.PluginAssemblyLoadContext.Assemblies.SelectMany(a => a.GetTypes()).Select(t => t.Name).Contains(typeName))
                .ToList();

            if (matchingPluginContainers.Count == 0)
            {
                throw new NoMatchedPluginException();
            }

            if (matchingPluginContainers.Count > 1)
            {
                return matchingPluginContainers.OrderByDescending(p => p.PluginLoadedAt).First();
            }

            return matchingPluginContainers.First();
        }

        public void AddPluginContainer(IPluginContainer pluginContainer)
        {
            var matchedPluginContainers = PluginContainersCollection.Select(p => p).Where(p => p.Equals(pluginContainer)).ToList();
            if (matchedPluginContainers.Count == 0)
            {
                PluginContainersCollection.Add(pluginContainer);
            }
            SetPluginContainersUpdatedAt(DateTime.UtcNow);
        }

        public void RemovePluginContainer(IPluginContainer pluginContainer)
        {
            var matchedPluginContainers = PluginContainersCollection.Select(p => p).Where(p => p.Equals(pluginContainer)).ToList();
            if (matchedPluginContainers.Count > 0)
            {
                PluginContainersCollection.Remove(pluginContainer);
            }
            SetPluginContainersUpdatedAt(DateTime.UtcNow);
        }
    }
}
