using System;
using System.Collections.Generic;

namespace DidactCore.Entities
{
    public class FlowVersion
    {
        public long FlowVersionId { get; set; }

        public long FlowId { get; set; }

        public long EnvironmentId { get; set; }

        public string Version { get; set; } = null!;

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime Updated { get; set; }

        public string UpdatedBy { get; set; } = null!;

        public bool Active { get; set; }

        public byte[] RowVersion { get; set; } = null!;

        public virtual Flow Flow { get; set; } = null!;

        public virtual Environment Environment { get; set; } = null!;

        public virtual ICollection<FlowRun> FlowRuns { get; } = new List<FlowRun>();
    }
}
