using System.Threading.Tasks;

namespace DidactEngine.Engine
{
    public interface IEngineRepository
    {
        Task<bool> CheckForEngineShutdownAsync();

        Task<EngineDto> GetEngineAsync();

        Task<EngineTuningDto> GetEngineTuningAsync();
    }
}
