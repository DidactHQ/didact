using System;

namespace DidactCore.Entities
{
    public class CronScheduleTrigger
    {
        public long CronScheduleTriggerId { get; set; }

        public long TriggerId { get; set; }

        public string CronExpression { get; set; } = null!;

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime Updated { get; set; }

        public string UpdatedBy { get; set; } = null!;

        public bool Active { get; set; }

        public byte[] RowVersion { get; set; } = null!;
    }
}
