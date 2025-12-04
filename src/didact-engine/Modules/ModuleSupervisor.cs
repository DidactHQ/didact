using DidactEngine.Engine;

namespace DidactEngine.Modules
{
    public class ModuleSupervisor : BackgroundService
    {
        private readonly ILogger<ModuleSupervisor> _logger;
        private readonly IEnumerable<IModule> _modules;
        private readonly IEngineService _engineService;

        public ModuleSupervisor(IEnumerable<IModule> modules, ILogger<ModuleSupervisor> logger, IEngineService engineService)
        {
            _modules = modules;
            _logger = logger;
            _engineService = engineService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Create a composite cancellation token that covers an engine shutdown event from the runtime as well as from manual engine polling.
            using var compositeCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(stoppingToken, _engineService.CancellationToken);
            var compositeCancellationToken = compositeCancellationTokenSource.Token;

            var moduleTasks = _modules
                .Where(m => m.Enabled)
                .SelectMany(m =>
                    Enumerable.Range(0, m.Concurrency)
                                .Select(_ => RunModuleLoopAsync(m, compositeCancellationToken)))
                .ToList();

            await Task.WhenAll(moduleTasks);
        }

        private async Task RunModuleLoopAsync(IModule module, CancellationToken ct)
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
                    await Task.Delay(module.IntervalDelay, ct);
                    continue; // restart the loop (revives the module)
                }

                await Task.Delay(module.IntervalDelay, ct);
            }
        }
    }
}