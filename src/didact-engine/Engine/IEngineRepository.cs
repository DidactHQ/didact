using System.Threading.Tasks;

namespace DidactCore.Engine
{
    public interface IEngineRepository
    {
        Task<bool> CheckForEngineShutdownAsync();

        Task<EngineDto> GetEngineAsync();

        Task<EngineTuningDto> GetEngineTuningAsync();
    }
}
