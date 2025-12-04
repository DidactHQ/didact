namespace DidactEngine.Engine
{
    public interface IEngineService
    {
        EngineContext? EngineContext { get; }

        CancellationToken CancellationToken { get; }

        Task PollEngineShutdownAsync();
    }
}
