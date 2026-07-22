namespace DidactEngine.Modules
{
    public interface IModule
    {
        string Name { get; }

        bool Enabled { get; }

        /// <summary>
        /// Modules that must be initialized before this module can start.
        /// </summary>
        IReadOnlyCollection<Type> Dependencies { get; }

        /// <summary>
        /// Performs bounded startup work and returns when the module is ready to run.
        /// </summary>
        Task InitializeAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Runs the module until engine cancellation or an unrecoverable failure.
        /// </summary>
        Task RunAsync(CancellationToken cancellationToken);
    }
}
