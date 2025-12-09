namespace DidactEngine.Modules
{
    public sealed class ModuleContext
    {
        public IModule Module { get; }

        public CancellationToken CancellationToken { get; }

        public Guid Id { get; } = Guid.NewGuid();

        public int WorkerIndex { get; }

        public string Name => $"{Module.Name} module (index: {WorkerIndex} | id: {Id})";

        public ModuleContext(IModule module, int workerIndex, CancellationToken cancellationToken)
        {
            Module = module;
            WorkerIndex = workerIndex;
            CancellationToken = cancellationToken;
        }
    }
}
