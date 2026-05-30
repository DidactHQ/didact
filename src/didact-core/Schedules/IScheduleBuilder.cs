using System;

namespace DidactCore.Schedules
{
    public interface IScheduleBuilder
    {
        string ScheduleType { get; }

        string Name { get; }

        string? Description { get; }

        string? TimeZone { get; }

        string? CronExpression { get; }

        long? IntervalSeconds { get; }

        DateTime? ExecuteAt { get; }

        string? ICalendarExpression { get; }

        IScheduleBuilder AsScheduleType(string scheduleType);

        IScheduleBuilder WithName(string name);

        IScheduleBuilder WithDescription(string description);

        IScheduleBuilder WithTimeZone(string timeZone);

        IScheduleBuilder WithCronExpression(string cronExpression);

        IScheduleBuilder WithIntervalSeconds(long intervalSeconds);

        IScheduleBuilder WithExecuteAt(DateTime executeAt);

        IScheduleBuilder WithICalendarExpression(string iCalendarExpression);
    }
}
