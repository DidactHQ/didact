namespace DidactEngine.Engine
{
    public class EngineTuningContext
    {
        // TODO Implement
        public decimal ThreadFactor { get; set; }

        public decimal TaskFactor { get; set; }

        public int FlowRunCancellationCheckInterval { get; set; }

        public int EngineShutdownCheckInterval { get; set; }
    }
}
