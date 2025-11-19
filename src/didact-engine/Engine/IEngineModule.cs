namespace DidactEngine.Engine
{
    public interface IEngineModule
    {
        string Name { get; }
        
        bool Enabled { get; }
        
        Task ExecuteAsync(CancellationToken ct);
    }
}
