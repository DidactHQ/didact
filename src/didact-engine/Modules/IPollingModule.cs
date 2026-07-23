namespace DidactEngine.Modules
{
    /// <summary>
    /// A module that repeatedly performs bounded polling work for its lifetime.
    /// </summary>
    public interface IPollingModule : IModule
    {
        TimeSpan PollingInterval { get; }
    }
}
