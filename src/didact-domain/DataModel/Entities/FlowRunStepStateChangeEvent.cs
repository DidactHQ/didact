using System;

namespace DidactDomain.DataModel.Entities
{
    public class FlowRunStepStateChangeEvent
    {
        public long FlowRunStepStateChangeEventId { get; set; }

        public long FlowRunEventId { get; set; }

        public long EnvironmentId { get; set; }

        public string? PreviousState { get; set; }

        public string? NewState { get; set; }

        public DateTime Timestamp { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime Updated { get; set; }

        public string UpdatedBy { get; set; } = null!;

        public bool Active { get; set; }

        public byte[] RowVersion { get; set; } = null!;
    }
}
