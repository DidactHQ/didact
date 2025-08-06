using System;

namespace DidactCore.Entities
{
    public class StrictQueueItem
    {
        public long StrictQueueItemId { get; set; }

        public long EnvironmentId { get; set; }

        public int StrictQueueId { get; set; }

        public long FlowRunId { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime Updated { get; set; }

        public string UpdatedBy { get; set; } = null!;

        public byte[] RowVersion { get; set; } = null!;

        public virtual StrictQueue StrictQueue { get; set; } = null!;

        public virtual Environment Environment { get; set; } = null!;

        public virtual FlowRun FlowRun { get; set; } = null!;
    }
}
