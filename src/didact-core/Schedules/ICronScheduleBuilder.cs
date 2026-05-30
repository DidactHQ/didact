namespace DidactCore.Schedules
{
    public interface ICronScheduleBuilder
    {
        string? Name { get; }

        string? CronExpression { get; }

        ICronScheduleBuilder WithName(string name);

        ICronScheduleBuilder WithCronExpression(string cronExpression);
    }
}
