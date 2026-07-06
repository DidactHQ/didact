using System;
using System.Collections.Generic;

namespace DidactDomain.DataModel.Entities
{
    public class FlowRunState
    {
        public int FlowRunStateId { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime Updated { get; set; }

        public string UpdatedBy { get; set; } = null!;

        public bool Active { get; set; }

        public byte[] RowVersion { get; set; } = null!;

        public virtual ICollection<FlowRun> FlowRuns { get; } = new List<FlowRun>();
    }
}
