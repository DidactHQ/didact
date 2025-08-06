using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace DidactCore.Plugins
{
    public class PluginAssemblyLoadContext : AssemblyLoadContext
    {
        private readonly AssemblyDependencyResolver _resolver;

        public PluginAssemblyLoadContext(string pluginPath)
        {
            _resolver = new AssemblyDependencyResolver(pluginPath);
        }

        protected override Assembly? Load(AssemblyName assemblyName)
        {
            // If the assembly is already loaded in the default AssemblyLoadContext,
            // then bypass the plugin's assembly and use the one from the default AssemblyLoadContext.
            var assembly = Default.Assemblies.FirstOrDefault(a => a.GetName().Name == assemblyName.Name);
            if (assembly is not null)
            {
                return assembly;
            }
            
            // Use the resolver to load other assemblies specific to this AssemblyLoadContext
            var assemblyPath = _resolver.ResolveAssemblyToPath(assemblyName);
            if (assemblyPath is not null)
            {
                return LoadFromAssemblyPath(assemblyPath);
            }

            return null;
        }

        protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
        {
            string? libraryPath = _resolver.ResolveUnmanagedDllToPath(unmanagedDllName);
            if (libraryPath is not null)
            {
                return LoadUnmanagedDllFromPath(libraryPath);
            }

            return IntPtr.Zero;
        }

        public IEnumerable<Assembly> GetAssemblies()
        {
            return Assemblies;
        }
    }
}