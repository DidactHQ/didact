using DidactEngine.Engine;

namespace DidactEngine.Modules
{
    public sealed class ModuleSupervisor : BackgroundService
    {
        private readonly ILogger<ModuleSupervisor> _logger;
        private readonly IReadOnlyCollection<IModule> _modules;
        private readonly IEngineService _engineService;

        public ModuleSupervisor(IEnumerable<IModule> modules, ILogger<ModuleSupervisor> logger, IEngineService engineService)
        {
            _modules = modules.ToArray();
            _logger = logger;
            _engineService = engineService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var engineCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(
                stoppingToken,
                _engineService.CancellationToken);

            var cancellationToken = engineCancellationTokenSource.Token;
            var modules = SortModulesByDependencies(_modules.Where(module => module.Enabled).ToArray());

            await InitializeModulesAsync(modules, cancellationToken);

            var moduleTasks = modules
                .Select(module => RunModuleAsync(module, cancellationToken))
                .ToArray();

            if (moduleTasks.Length == 0)
            {
                _logger.LogWarning("No engine modules are enabled.");
                return;
            }

            await Task.WhenAny(moduleTasks);

            if (!cancellationToken.IsCancellationRequested)
            {
                _logger.LogCritical("An engine module stopped unexpectedly. Cancelling all modules.");
                await engineCancellationTokenSource.CancelAsync();
            }

            await Task.WhenAll(moduleTasks);
        }

        private async Task InitializeModulesAsync(
            IReadOnlyCollection<IModule> modules,
            CancellationToken cancellationToken)
        {
            foreach (var module in modules)
            {
                _logger.LogInformation("Initializing module {ModuleName}.", module.Name);
                await module.InitializeAsync(cancellationToken);
                _logger.LogInformation("Module {ModuleName} initialized.", module.Name);
            }
        }

        private async Task RunModuleAsync(IModule module, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting module {ModuleName}.", module.Name);

            try
            {
                await module.RunAsync(cancellationToken);

                if (!cancellationToken.IsCancellationRequested)
                {
                    throw new InvalidOperationException($"Module '{module.Name}' exited unexpectedly.");
                }
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {
                _logger.LogInformation("Module {ModuleName} stopped due to engine cancellation.", module.Name);
            }
            catch (Exception exception)
            {
                _logger.LogCritical(exception, "Module {ModuleName} failed fatally.", module.Name);
                throw;
            }
        }

        private static IReadOnlyList<IModule> SortModulesByDependencies(IReadOnlyCollection<IModule> modules)
        {
            var modulesByType = modules.ToDictionary(module => module.GetType());
            var sortedModules = new List<IModule>(modules.Count);
            var visiting = new HashSet<Type>();
            var visited = new HashSet<Type>();

            foreach (var module in modules)
            {
                Visit(module);
            }

            return sortedModules;

            void Visit(IModule module)
            {
                var moduleType = module.GetType();

                if (visited.Contains(moduleType))
                    return;

                if (!visiting.Add(moduleType))
                    throw new InvalidOperationException($"A circular module dependency includes '{module.Name}'.");

                foreach (var dependencyType in module.Dependencies)
                {
                    if (!modulesByType.TryGetValue(dependencyType, out var dependency))
                    {
                        throw new InvalidOperationException(
                            $"Module '{module.Name}' requires missing or disabled module '{dependencyType.Name}'.");
                    }

                    Visit(dependency);
                }

                visiting.Remove(moduleType);
                visited.Add(moduleType);
                sortedModules.Add(module);
            }
        }
    }
}
