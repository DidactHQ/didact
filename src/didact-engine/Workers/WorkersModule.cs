using DidactEngine.Constants;
using DidactEngine.Modules;

namespace DidactEngine.Workers
{
    public class WorkersModule : IModule
    {
        public string Name => EngineConstants.ModuleNames.Workers;

        public bool Enabled { get; set; } = true;

        // TODO Implement custom concurrency from default and/or config.json
        public int Concurrency { get; set; } = Environment.ProcessorCount;

        public int IntervalDelay { get; set; } = Defaults.DefaultModuleIntervalDelays.Workers;

        public Task ExecuteAsync(CancellationToken cancellationToken)
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
