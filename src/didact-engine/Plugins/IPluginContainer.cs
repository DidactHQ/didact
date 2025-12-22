namespace DidactEngine.Plugins
{
    public interface IPluginContainer
    {
        IPluginContainerContext PluginContainerContext { get; }

        DateTime? PluginLoadedAt { get; set; }

        DateTime? LastExecution { get; set; }

        /// <summary>
        /// Configures the plugin's dependency injection system.
        /// </summary>
        void ConfigureDependencyInjection();

        /// <summary>
        /// Retrieves all Flow types from the plugin's assemblies using reflection,
        /// instantiates each Flow type using the plugin dependency injection system,
        /// and runs their configuration functions.
        /// If configuration fails for a specific set of Flows,
        /// gracefully handles the failures and passes through the successes.
        /// </summary>
        /// <returns></returns>
        Task ConfigureFlowsAsync();
    }
}
