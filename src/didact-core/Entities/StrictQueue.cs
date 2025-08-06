using System;
using System.Collections.Generic;

namespace DidactCore.Entities
{
    public class StrictQueue
    {
        public int StrictQueueId { get; set; }

        public int QueueDirectionId { get; set; }

        public long EnvironmentId { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime Updated { get; set; }

        public string UpdatedBy { get; set; } = null!;

        public bool Active { get; set; }

        public byte[] RowVersion { get; set; } = null!;

        public virtual QueueDirection QueueDirection { get; set; } = null!;

        public virtual Environment Environment { get; set; } = null!;

        public virtual ICollection<StrictQueueItem> StrictQueueItems { get; } = new List<StrictQueueItem>();
    }
}
