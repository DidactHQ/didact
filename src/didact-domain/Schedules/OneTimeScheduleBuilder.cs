using DidactCore.Schedules;
using System;

namespace DidactDomain.Schedules
{
    public class OneTimeScheduleBuilder : IOneTimeScheduleBuilder
    {
        public string? Name { get; private set; }

        public DateTime? ExecuteAt { get; private set; }

        public IOneTimeScheduleBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public IOneTimeScheduleBuilder ScheduleExecutionAt(DateTime executeAt)
        {
            ExecuteAt = executeAt;
            return this;
        }
    }
}
