using System;
using System.Collections.Generic;

namespace DidactCore.Entities
{
    public class Flow
    {
        public long FlowId { get; set; }

        public long EnvironmentId { get; set; }

        public long LibraryId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string TypeName { get; set; } = null!;

        public int ExecutionModeId { get; set; }

        public int ConcurrencyLimit { get; set; }

        public string DefaultQueueType { get; set; } = null!;

        public string DefaultQueueName { get; set; } = null!;

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime Updated { get; set; }

        public string UpdatedBy { get; set; } = null!;

        public bool Active { get; set; }

        public byte[] RowVersion { get; set; } = null!;

        public virtual Environment Environment { get; set; } = null!;

        public virtual ExecutionMode ExecutionMode { get; set; } = null!;

        public virtual ICollection<FlowRun> FlowRuns { get; } = new List<FlowRun>();
    }
}
