using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DidactCore.Engine
{
    public class EngineRepository : IEngineRepository
    {
        private readonly ILogger<IEngineRepository> _logger;

        public EngineRepository(ILogger<IEngineRepository> logger)
        {
            _logger = logger;
        }

        public async Task<bool> CheckForEngineShutdownAsync()
        {
            // TODO Implement
            await Task.CompletedTask;
            return false;
        }

        public async Task<EngineDto> GetEngineAsync()
        {
            // TODO Implement
            await Task.CompletedTask;
            return new EngineDto();
        }

        public async Task<EngineTuningDto> GetEngineTuningAsync()
        {
            // TODO Implement
            await Task.CompletedTask;
            return new EngineTuningDto();
        }
    }
}
