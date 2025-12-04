using DidactEngine.Constants;
using DidactEngine.Modules;

namespace DidactEngine.Plugins
{
    public class PluginsModule : IModule
    {
        public string Name => EngineConstants.ModuleNames.Plugins;

        public bool Enabled { get; set; } = true;

        public int Concurrency { get; set; } = 1;

        public int IntervalDelay { get; set; } = Defaults.DefaultModuleIntervalDelays.Plugins;

        public PluginsModule() { }

        public async Task ExecuteAsync(CancellationToken ct)
        {
            // TODO

            /* Implementation
             * Step 1: Poll database for missing deployments.
             * Step 2: Fetch each deployment.
             * Step 3: Shadow copy each deployment.
             * Step 4: Load each deployment in a new ALC.
             * Step 5: Implement plugin-isolated dependency injection.
             * Step 6: Run ConfigureAsync against all flows.
             */

            await Task.CompletedTask;
        }
    }
}
