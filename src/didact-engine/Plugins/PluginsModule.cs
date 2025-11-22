using DidactEngine.Constants;
using DidactEngine.Engine;

namespace DidactEngine.Plugins
{
    public class PluginsModule : IEngineModule
    {
        public string Name => EngineConstants.EngineModuleNames.Plugins;
        public bool Enabled { get; set; } = true;

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
