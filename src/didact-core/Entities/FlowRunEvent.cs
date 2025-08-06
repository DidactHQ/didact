using System;

namespace DidactCore.Entities
{
    public class FlowRunEvent
    {
        public long FlowRunEventId { get; set; }

        public long FlowRunId { get; set; }

        public int FlowRunEventTypeId { get; set; }

        public long EnvironmentId { get; set; }

        public DateTime OccurredAt { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime Updated { get; set; }

        public string UpdatedBy { get; set; } = null!;

        public byte[] RowVersion { get; set; } = null!;

        public virtual FlowRun FlowRun { get; set; } = null!;

        public virtual FlowRunEventType FlowRunEventType { get; set; } = null!;

        public virtual Environment Environment { get; set; } = null!;
    }
}
