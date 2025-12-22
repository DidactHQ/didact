using DidactCore.Flows;
using DidactCore.Plugins;
using DidactEngine.Flows;
using System.Reflection;

namespace DidactEngine.Plugins
{
    public class PluginContainer : IPluginContainer
    {
        private readonly ILogger<IPluginContainer> _logger;
        private readonly PluginAssemblyLoadContext _pluginAssemblyLoadContext;
        private readonly IPluginDependencyInjector _pluginDependencyInjector;
        private readonly IFlowRepository _flowRepository;

        public IPluginContainerContext PluginContainerContext { get; }

        public Dictionary<string, Type> PluginTypes { get; } = [];

        public DateTime? PluginLoadedAt { get; set; }

        public DateTime? LastExecution { get; set; }

        public PluginContainer(ILogger<IPluginContainer> logger, IPluginDependencyInjector pluginDependencyInjector,
            PluginAssemblyLoadContext pluginAssemblyLoadContext, IFlowRepository flowRepository,
            IPluginContainerContext pluginContainerContext)
        {
            _logger = logger;
            _pluginDependencyInjector = pluginDependencyInjector;
            _pluginAssemblyLoadContext = pluginAssemblyLoadContext;
            _flowRepository = flowRepository;
            PluginContainerContext = pluginContainerContext;
        }

        private IEnumerable<Assembly> GetAssemblies() => _pluginAssemblyLoadContext.Assemblies;

        private IEnumerable<Type> GetFlowTypes()
        {
            return GetAssemblies().SelectMany(s => s.GetTypes())
                .Where(t => t.GetInterfaces().Contains(typeof(IFlow)) && t.IsClass && !t.IsAbstract);
        }

        public void ConfigureDependencyInjection()
        {
            var registrarType = GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(t => t.GetInterfaces().Contains(typeof(IPluginRegistrar)) && t.IsClass && !t.IsAbstract)
                .SingleOrDefault();

            // If a flow library does not have a registrar, early return.
            // For now, we will not make registrars a requirement.
            if (registrarType is null)
            {
                _logger.LogWarning("The {pluginContainerTypeName} does not have an {registrarType}. Skipping dependency injection for this plugin...",
                    nameof(IPluginContainer), nameof(IPluginRegistrar));
                return;
            }

            // Instantiate the registrar.
            IPluginRegistrar? registrar;
            try
            {
                registrar = Activator.CreateInstance(registrarType) as IPluginRegistrar;
            }
            catch (Exception ex)
            {
                throw new PluginConfigurationException(
                    $"The plugin failed to configure because the {nameof(IPluginRegistrar)} could not be instantiated. See inner exception.", ex);
            }

            if (registrar is null)
            {
                throw new PluginConfigurationException(
                    $"The plugin failed to configure because the {nameof(IPluginRegistrar)} could not be instantiated.");
            }

            // Build the plugin's IServiceProvider.
            try
            {
                var pluginServiceCollection = registrar.RegisterServices(new ServiceCollection());
                _pluginDependencyInjector.BuildServiceCollection(pluginServiceCollection);
            }
            catch (Exception ex)
            {
                throw new PluginConfigurationException(
                    $"The plugin failed to configure because the {nameof(IPluginRegistrar.RegisterServices)} method encountered an unhandled exception. See inner exception.", ex);
            }
        }

        private IPluginFlowConfigurationContext ValidateFlowConfiguration(IPluginFlowConfigurationContext context)
        {
            if (context.FlowConfigurationContext.Configurator.Name is null)
                context.FlowConfigurationContext.Configurator.WithName(context.FlowType.Name);

            if (context.FlowConfigurationContext.Configurator.Version is null)
                context.FlowConfigurationContext.Configurator.AsVersion(DidactCore.Constants.Defaults.DefaultFlowVersion);

            return context;
        }

        private async Task<IPluginFlowConfigurationContext> ConfigureFlowAsync(IPluginFlowConfigurationContext context)
        {
            // Step 1: Instantiate the flow.
            var iFlow = _pluginDependencyInjector.CreateInstance(context.FlowType) as IFlow
                ?? throw new FlowConfigurationException($"The plugin flow type {context.FlowType} could not be instantiated for configuration.");

            // Step 2: Run the flow's metadata collection configuration.
            try
            {
                context.FlowConfigurationContext = await iFlow.ConfigureAsync(context.FlowConfigurationContext);
            }
            catch (Exception ex)
            {
                throw new FlowConfigurationException($"Flow configuration failed for plugin flow type {context.FlowType}. See inner exception.", ex);
            }

            // Step 3: Set defaults for and validate IFlowConfigurationContext.
            context = ValidateFlowConfiguration(context);

            // TODO Step 4: Save the flow configuration to the database.

            return context;
        }

        public async Task ConfigureFlowsAsync()
        {
            var flowTypes = GetFlowTypes();

            foreach (var flowType in flowTypes)
            {
                // Initialize all required contexts.
                var flowConfigurator = new FlowConfigurator();
                var flowConfigurationContext = new FlowConfigurationContext(
                    PluginContainerContext.EnvironmentContext, PluginContainerContext.DeploymentContext, flowConfigurator);
                var pluginFlowConfigurationContext = new PluginFlowConfigurationContext(flowType, flowConfigurationContext, null);

                try
                {
                    IPluginFlowConfigurationContext configuredContext = await ConfigureFlowAsync(pluginFlowConfigurationContext);
                    var flowName = configuredContext.FlowConfigurationContext.Configurator.Name;
                    var flowVersion = configuredContext.FlowConfigurationContext.Configurator.Version;
                    
                }
                catch (FlowConfigurationException ex)
                {
                    _logger.LogError(ex, "The plugin's flow type {flowType} failed to configure.", flowType);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An unhandled exception occurred trying to configure the plugin's flow type {flowType}.", flowType);
                }
            }

            // TODO Need to build flow type Dictionary so that I know what succeeded and what failed.
        }
    }
}
