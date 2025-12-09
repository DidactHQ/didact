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
            /* Create a composite cancellation token that covers an engine shutdown event from the runtime
             * as well as from manual engine polling.
             */
            using var compositeCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(stoppingToken, _engineService.CancellationToken);
            var compositeCancellationToken = compositeCancellationTokenSource.Token;

            var moduleTasks = _modules
                .Where(m => m.Enabled)
                .SelectMany(m =>
                    Enumerable.Range(0, m.Concurrency)
                                .Select(i => RunModuleLoopAsync(new ModuleContext(m, i + 1, compositeCancellationToken))))
                .ToList();

            await Task.WhenAll(moduleTasks);
        }

        private async Task RunModuleLoopAsync(ModuleContext moduleContext)
        {
            _logger.LogInformation("{name} starting {supervisorName} execution loop...", moduleContext.Name, nameof(ModuleSupervisor));

            while (!moduleContext.CancellationToken.IsCancellationRequested && moduleContext.Module.Enabled)
            {
                try
                {
                    await moduleContext.Module.ExecuteAsync(moduleContext.CancellationToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "{Name} crashed. Restarting...", moduleContext.Name);
                    await Task.Delay(moduleContext.Module.IntervalDelay, moduleContext.CancellationToken);
                    continue; // restart the loop (revives the module)
                }

                await Task.Delay(moduleContext.Module.IntervalDelay, moduleContext.CancellationToken);
            }

            _logger.LogWarning("{name} {supervisorName} execution loop stopped.", moduleContext.Name, nameof(ModuleSupervisor));
        }
    }
}