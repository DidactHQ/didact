using DidactCore.Constants;
using DidactCore.Plugins;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace DidactCore.Engine
{
    public class EngineSupervisor : IEngineSupervisor
    {
        public long EngineId { get; set; }

        public string MachineName { get; set; } = Environment.MachineName;

        public int ProcessId { get; set; } = Process.GetCurrentProcess().Id;

        public Guid EngineGuid { get; set; } = Guid.NewGuid();

        public Guid EngineUniversalId { get; set; }

        public EngineTuningDto? EngineTuning { get; set; }

        public string EngineState { get; set; } = EngineStates.StartingUp;

        public CancellationToken CancellationToken { get; set; }

        public DateTime EngineStateUpdated { get; set; } = DateTime.Now;

        public IPluginContainers? PluginContainers { get; set; }

        private readonly ILogger<EngineSupervisor> _logger;
        private readonly IEngineRepository _engineRepository;
        private readonly CancellationTokenSource _cancellationTokenSource;

        public EngineSupervisor(ILogger<EngineSupervisor> logger, IEngineRepository engineRepository)
        {
            _logger = logger;
            _engineRepository = engineRepository;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public void SetEngineState(string engineState)
        {
            EngineState = engineState;
            EngineStateUpdated = DateTime.Now;
        }

        public async Task CheckForEngineShutdownEventAsync()
        {
            // TODO Finish implementing
            await _engineRepository.CheckForEngineShutdownAsync();
        }

        public string GetEngineState()
        {
            return EngineState;
        }

        public DateTime GetEngineStateUpdated()
        {
            return EngineStateUpdated;
        }
    }
}
