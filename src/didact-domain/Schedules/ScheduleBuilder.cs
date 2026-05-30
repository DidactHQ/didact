using DidactCore.Schedules;
using System;

namespace DidactDomain.Schedules
{
    public class ScheduleBuilder : IScheduleBuilder
    {
        public string ScheduleType { get; private set; } = null!;

        public string Name { get; private set; } = null!;
        
        public string? Description { get; private set; }
        
        public string? TimeZone { get; private set; }
        
        public string? CronExpression { get; private set; }
        
        public long? IntervalSeconds { get; private set; }
        
        public DateTime? ExecuteAt { get; private set; }
        
        public string? ICalendarExpression { get; private set; }

        public IScheduleBuilder AsScheduleType(string scheduleType)
        {
            ScheduleType = scheduleType;
            return this;
        }

        public IScheduleBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public IScheduleBuilder WithDescription(string description)
        {
            Description = description;
            return this;
        }

        public IScheduleBuilder WithTimeZone(string timeZone)
        {
            TimeZone = timeZone;
            return this;
        }

        public IScheduleBuilder WithCronExpression(string cronExpression)
        {
            CronExpression = cronExpression;
            return this;
        }

        public IScheduleBuilder WithIntervalSeconds(long intervalSeconds)
        {
            IntervalSeconds = intervalSeconds;
            return this;
        }

        public IScheduleBuilder WithExecuteAt(DateTime executeAt)
        {
            ExecuteAt = executeAt;
            return this;
        }

        public IScheduleBuilder WithICalendarExpression(string iCalendarExpression)
        {
            ICalendarExpression = iCalendarExpression;
            return this;
        }
    }
}
