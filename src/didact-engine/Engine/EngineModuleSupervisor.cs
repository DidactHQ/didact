namespace DidactEngine.Engine
{
    public class EngineModuleSupervisor : BackgroundService
    {
        private readonly IEnumerable<IEngineModule> _modules;
        private readonly ILogger<EngineModuleSupervisor> _logger;

        public EngineModuleSupervisor(IEnumerable<IEngineModule> modules, ILogger<EngineModuleSupervisor> logger)
        {
            _modules = modules;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // optional: run modules in parallel or sequence
            var tasks = _modules
                .Where(m => m.Enabled)
                .Select(m => RunModuleLoopAsync(m, stoppingToken))
                .ToList();

            await Task.WhenAll(tasks);
        }

        private async Task RunModuleLoopAsync(IEngineModule module, CancellationToken ct)
        {
            while (!ct.IsCancellationRequested && module.Enabled)
            {
                try
                {
                    await module.ExecuteAsync(ct);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "{Name} module crashed. Restarting...", module.Name);

                    // Optional: exponential backoff or fixed delay
                    //await Task.Delay(module.RetryDelay, ct);

                    continue; // restart the loop (revives the module)
                }
                
                // optional delay, per-module rate control
                //await Task.Delay(module.Interval, ct);
            }
        }
    }
}