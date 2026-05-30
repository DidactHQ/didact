using DidactCore.Schedules;

namespace DidactDomain.Schedules
{
    public class CronScheduleBuilder : ICronScheduleBuilder
    {
        public string? Name { get; private set; }

        public string? CronExpression { get; private set; }

        public ICronScheduleBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public ICronScheduleBuilder WithCronExpression(string cronExpression)
        {
            CronExpression = cronExpression;
            return this;
        }
    }
}
