using System;

namespace DidactCore.Entities
{
    public class FlowSchedule
    {
        public long FlowScheduleId { get; set; }

        public long EnvironmentId { get; set; }

        public long FlowId { get; set; }

        public int ScheduleTypeId { get; set; }

        public string CronExpression { get; set; } = null!;

        public DateTime? LastRunTime { get; set; }

        public DateTime? NextRunTime { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime Updated { get; set; }

        public string UpdatedBy { get; set; } = null!;

        public bool Active { get; set; }

        public byte[] RowVersion { get; set; } = null!;

        public virtual Environment Environment { get; set; } = null!;

        public virtual ScheduleType ScheduleType { get; set; } = null!;

        public virtual Flow Flow { get; set; } = null!;
    }
}
