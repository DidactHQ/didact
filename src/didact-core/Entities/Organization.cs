using System;
using System.Collections.Generic;

namespace DidactCore.Entities
{
    public class Organization
    {
        public int OrganizationId { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime Updated { get; set; }

        public string UpdatedBy { get; set; } = null!;

        public bool Active { get; set; }

        public byte[] RowVersion { get; set; } = null!;

        public virtual ICollection<Flow> Flows { get; } = new List<Flow>();

        public virtual ICollection<FlowRun> FlowRuns { get; } = new List<FlowRun>();

        public virtual ICollection<BlockRun> BlockRuns { get; } = new List<BlockRun>();

        public virtual ICollection<HyperQueue> HyperQueues { get; } = new List<HyperQueue>();

        public virtual ICollection<StrictQueue> StrictQueues { get; } = new List<StrictQueue>();

        public virtual ICollection<HyperQueueItem> HyperQueueItems { get; } = new List<HyperQueueItem>();

        public virtual ICollection<StrictQueueItem> StrictQueueItems { get; } = new List<StrictQueueItem>();

        public virtual ICollection<Engine> Engines { get; } = new List<Engine>();
    }
}
