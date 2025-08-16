namespace DidactCore.Engine
{
    public class EngineTuningDto
    {
        // TODO Implement
        public decimal ThreadFactor { get; set; }

        public decimal TaskFactor { get; set; }

        public int FlowRunCancellationCheckInterval { get; set; }

        public int EngineShutdownCheckInterval { get; set; }
    }
}
