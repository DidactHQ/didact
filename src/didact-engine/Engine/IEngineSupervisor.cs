using DidactCore.Plugins;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DidactCore.Engine
{
    public interface IEngineSupervisor
    {
        long EngineId { get; set; }

        Guid EngineUniversalId { get; set; }

        EngineTuningDto EngineTuning { get; set; }

        string EngineState { get; set; }

        CancellationToken CancellationToken { get; set; }

        DateTime EngineStateUpdated { get; set; }

        IPluginContainers PluginContainers { get; set; }

        void SetEngineState(string engineState);

        Task CheckForEngineShutdownEventAsync();

        string GetEngineState();

        DateTime GetEngineStateUpdated();
    }
}
