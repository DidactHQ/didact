using System;

namespace DidactCore.Entities
{
    public class FlowRunStateChangeEvent
    {
        public long FlowRunStateChangeEventId { get; set; }

        public long FlowRunEventId { get; set; }

        public long EnvironmentId { get; set; }

        public string PreviousState { get; set; } = null!;

        public string NewState { get; set; } = null!;

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime Updated { get; set; }

        public string UpdatedBy { get; set; } = null!;

        public bool Active { get; set; }

        public byte[] RowVersion { get; set; } = null!;
    }
}
