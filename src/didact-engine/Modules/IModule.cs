namespace DidactEngine.Modules
{
    public interface IModule
    {
        string Name { get; }

        bool Enabled { get; set; }

        string State { get; set; }

        /// <summary>
        /// Modules that must be initialized before this module can start.
        /// </summary>
        IReadOnlyCollection<Type> Dependencies { get; }

        /// <summary>
        /// Runs the module until engine cancellation or an unrecoverable failure.
        /// </summary>
        Task RunAsync(CancellationToken cancellationToken);
    }
}
