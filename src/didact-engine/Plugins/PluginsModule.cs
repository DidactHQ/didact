using DidactEngine.Constants;
using DidactEngine.Modules;

namespace DidactEngine.Plugins
{
    public sealed class PluginsModule : PollingModule
    {
        public PluginsModule(ILogger<PluginsModule> logger)
            : base(logger)
        {
        }

        public override string Name => EngineConstants.ModuleNames.Plugins;

        public override TimeSpan PollingInterval =>
            TimeSpan.FromMilliseconds(Defaults.DefaultModuleIntervalDelays.Plugins);

        protected override Task PollAsync(CancellationToken cancellationToken)
        {
            /* Implementation
             * Step 1: Poll database for missing deployments.
             * Step 2: Fetch each deployment.
             * Step 3: Shadow copy each deployment.
             * Step 4: Load each deployment in a new ALC.
             * Step 5: Implement plugin-isolated dependency injection.
             * Step 6: Run ConfigureAsync against all flows.
             */

            return Task.CompletedTask;
        }
    }
}
