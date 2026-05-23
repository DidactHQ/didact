using System;

namespace DidactDomain.DataModel.Entities
{
    public class Schedule
    {
        public long ScheduleId { get; set; }

        public int ScheduleTypeId { get; set; }

        public long FlowId { get; set; }

        public long EnvironmentId { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string? TimeZone { get; set; }

        public string? CronExpression { get; set; }

        public long? IntervalSeconds { get; set; }

        public DateTime? ExecuteAt { get; set; }

        public string? ICalendarExpression { get; set; }

        public DateTime? LastRunAt { get; set; }

        public DateTime? NextRunAt { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime Updated { get; set; }

        public string UpdatedBy { get; set; } = null!;

        public bool Active { get; set; }

        public byte[] RowVersion { get; set; } = null!;
    }
}
