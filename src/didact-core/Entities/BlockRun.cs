using System;

namespace DidactCore.Entities
{
    public class BlockRun
    {
        public long BlockRunId { get; set; }

        public long FlowRunId { get; set; }

        public long EnvironmentId { get; set; }

        public string? BlockName { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime? ExecutionStarted { get; set; }

        public DateTime? ExecutionEnded { get; set; }

        public int StateId { get; set; }

        public DateTime StateUpdated { get; set; }

        public string StateUpdatedBy { get; set; } = null!;

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime Updated { get; set; }

        public string UpdatedBy { get; set; } = null!;

        public bool Active { get; set; }

        public byte[] RowVersion { get; set; } = null!;

        public virtual FlowRun FlowRun { get; set; } = null!;

        public virtual Environment Environment { get; set; } = null!;

        public virtual State State { get; set; } = null!;
    }
}
