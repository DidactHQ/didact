using DidactEngine.Constants;
using DidactEngine.Engine;

namespace DidactEngine.Workers
{
    public class WorkersModule : IEngineModule
    {
        public string Name => EngineConstants.EngineModuleNames.Workers;
        public bool Enabled { get; set; } = true;

        public Task ExecuteAsync(CancellationToken ct)
        {
            // TODO

            /* Implementation
             * Step 1: Poll database for strictly-compatible flowruns (meaning the deployments are loaded as plugins already).
             * Step 2: Instantiate each flowrun.
             * Step 3: Execute each flowrun.
             */

            return Task.CompletedTask;
        }
    }
}
