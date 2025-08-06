namespace DidactCore.Triggers
{
    public interface ICronScheduleTrigger : ITrigger
    {
        string CronExpression { get; set; }
    }
}
