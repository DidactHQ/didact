using DidactCore.Constants;
using DidactCore.Flows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DidactCore.Plugins
{
    public class PluginContainer : IPluginContainer
    {
        public PluginAssemblyLoadContext? PluginAssemblyLoadContext { get; set; }

        public ICollection<PluginExecutionVersion> PluginExecutionVersions { get; set; } = [];

        public DateTime PluginLoadedAt { get; set; }

        public IPluginDependencyInjector PluginDependencyInjector { get; set; }

        public PluginContainer(IPluginDependencyInjector pluginDependencyInjector)
        {
            PluginDependencyInjector = pluginDependencyInjector;
        }

        // TODO Implement custom exception
        public IEnumerable<Assembly> GetAssemblies() => PluginAssemblyLoadContext?.Assemblies ?? throw new Exception("Missing ALC!");

        public void SetPluginLoadedAt(DateTime? pluginLoadedAt) => PluginLoadedAt = pluginLoadedAt ?? DateTime.UtcNow;

        public void ConfigureDependencyInjection()
        {
            var registrarType = GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(t => t.GetInterfaces().Contains(typeof(IPluginRegistrar)) && t.IsClass && !t.IsAbstract)
                .SingleOrDefault();

            if (registrarType is null)
            {
                // TODO throw a special exception here.
                throw new Exception("The plugin is missing a dependency injection registrar.");
            }

            var registrar = Activator.CreateInstance(registrarType) as IPluginRegistrar;

            if (registrar is null)
            {
                // TODO throw a special exception here.
                throw new Exception("The plugin registrar could not be instantiated.");
            }

            var pluginServiceCollection = registrar.CreateServiceCollection();
            PluginDependencyInjector.AddAndRebuildServiceCollection(pluginServiceCollection);
        }

        public async Task CollectPluginExecutionVersionsAsync()
        {
            var flowConfigurators = new List<FlowConfiguratorDto>();
            var flowTypes = GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(t => t.GetInterfaces().Contains(typeof(IFlow)) && t.IsClass && !t.IsAbstract);

            foreach (var flowType in flowTypes)
            {
                var iflow = PluginDependencyInjector.CreateInstance(flowType) as IFlow;
                if (iflow is null)
                {
                    // TODO throw exception
                    continue;
                }

                var newFlowConfigurator = PluginDependencyInjector.CreateInstance<IFlowConfigurator>();
                var flowConfigurator = await iflow.ConfigureAsync(newFlowConfigurator);

                var flowTypeName = flowConfigurator.TypeName;
                var flowVersion = flowConfigurator.Version;
                var assemblyName = flowType.Assembly.GetName().Name;
                var assemblyVersion = flowType.Assembly.GetName().Version?.ToString() ?? "Unknown";

                var pluginExecutionVersion = new PluginExecutionVersion(flowTypeName, flowVersion, assemblyName, assemblyVersion);
                PluginExecutionVersions.Add(pluginExecutionVersion);
            }
        }

        public async Task ConfigureFlowsAsync()
        {
            var flowConfigurators = new List<FlowConfiguratorDto>();
            var flowTypes = GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(t => t.GetInterfaces().Contains(typeof(IFlow)) && t.IsClass && !t.IsAbstract);

            // Configurator part 1: instantiate the Flows.
            foreach (var flowType in flowTypes)
            {
                var iflow = PluginDependencyInjector.CreateInstance(flowType) as IFlow;

                if (iflow is null)
                {
                    var exception = new Exception(
                        $"The Flow type {flowType.Name} could not be instantiated with dependency injection during Flow configuration.");
                    var notInstantiatedFlowConfigurator = new FlowConfiguratorDto()
                    {
                        FlowType = flowType,
                        State = FlowConfiguratorStates.FlowInstantiationFailed,
                        Exception = exception
                    };
                    flowConfigurators.Add(notInstantiatedFlowConfigurator);
                    continue;
                }

                var instantiatedFlowConfigurator = new FlowConfiguratorDto()
                {
                    FlowType = flowType,
                    State = FlowConfiguratorStates.FlowInstantiationSuccessful,
                    FlowInstance = iflow
                };
                flowConfigurators.Add(instantiatedFlowConfigurator);
            }

            // Configurator part 2: execute the configuration functions.
            foreach (var flowConfiguratorDto in flowConfigurators.Where(c => c.State == FlowConfiguratorStates.FlowInstantiationSuccessful))
            {
                try
                {
                    var newFlowConfigurator = PluginDependencyInjector.CreateInstance<IFlowConfigurator>();
                    var iFlowConfigurator = await flowConfiguratorDto.FlowInstance!.ConfigureAsync(newFlowConfigurator);
                    //await _flowRepository.SaveConfigurationsAsync(iFlowConfigurator);
                    flowConfiguratorDto.State = FlowConfiguratorStates.FlowConfigurationSuccessful;
                }
                catch (Exception ex)
                {
                    var exception = new Exception(
                        $"The Flow configurator for Flow type {flowConfiguratorDto.FlowType.Name} has failed. See inner exception.", ex);
                    flowConfiguratorDto.Exception = exception;
                    flowConfiguratorDto.State = FlowConfiguratorStates.FlowConfigurationFailed;
                }
            }

            foreach (var flowConfigurator in flowConfigurators.Where(c => c.State == FlowConfiguratorStates.FlowInstantiationFailed))
            {
                // TODO Handle failed flow instantiations.
            }

            foreach (var flowConfigurator in flowConfigurators.Where(c => c.State == FlowConfiguratorStates.FlowConfigurationFailed))
            {
                // TODO Handle failed flow configurations.
            }

            foreach (var flowConfigurator in flowConfigurators.Where(c => c.State == FlowConfiguratorStates.FlowConfigurationSuccessful))
            {
                // TODO Handle successful flow configurators.
            }
        }
    }
}
