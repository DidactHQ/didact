using DidactEngine.Constants;

namespace DidactEngine.Threading
{
    public class ThreadpoolService
    {
        public string ShutdownMode { get; private set; } = EngineConstants.ThreadpoolShutdownModes.Immediate;

        public decimal ThreadFactor { get; set; } = Defaults.DefaultThreadFactor;

        public CancellationToken CancellationToken { get; set; }

        public ThreadpoolService() { }
    }
}
