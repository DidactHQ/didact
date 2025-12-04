namespace DidactEngine.Modules
{
    public interface IModule
    {
        string Name { get; }
        
        bool Enabled { get; }

        /// <summary>
        /// The number of concurrent module <see cref="Task"/>s that can be created in the module supervisor.
        /// </summary>
        int Concurrency { get; }

        /// <summary>
        /// The delay from one module loop iteration to the next. The unit is milliseconds.
        /// </summary>
        int IntervalDelay { get; }
        
        Task ExecuteAsync(CancellationToken ct);
    }
}
