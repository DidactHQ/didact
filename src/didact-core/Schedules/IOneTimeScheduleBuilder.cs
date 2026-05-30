using System;

namespace DidactCore.Schedules
{
    public interface IOneTimeScheduleBuilder
    {
        string? Name { get; }

        DateTime? ExecuteAt { get; }

        IOneTimeScheduleBuilder WithName(string name);

        IOneTimeScheduleBuilder ScheduleExecutionAt(DateTime executeAt);
    }
}
