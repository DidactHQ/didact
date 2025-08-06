using DidactCore.Constants;

namespace DidactCore.Triggers
{
    public class CronScheduleTrigger : ICronScheduleTrigger
    {
        public string TriggerType { get; } = TriggerTypes.CronSchedule;

        public string TriggerScope { get; set; } = TriggerScopes.Flow;

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string CronExpression { get; set; } = null!;

        // TODO Implement later?
        //public long? ExistingCronScheduleTriggerId { get; set; }

        public CronScheduleTrigger(string cronExpression, string triggerScope = TriggerScopes.Flow)
        {
            CronExpression = cronExpression;
            TriggerScope = triggerScope;
        }

        public CronScheduleTrigger(string cronExpression, string name, string triggerScope = TriggerScopes.Flow)
        {
            CronExpression = cronExpression;
            Name = name;
            TriggerScope = triggerScope;
        }

        public CronScheduleTrigger(string cronExpression, string name, string description, string triggerScope = TriggerScopes.Flow)
        {
            CronExpression= cronExpression;
            Name = name;
            Description = description;
            TriggerScope = triggerScope;
        }

        // TODO Implement later?
        //public CronScheduleTrigger(long existingCronScheduleTriggerId)
        //{
        //    ExistingCronScheduleTriggerId = existingCronScheduleTriggerId;
        //}
    }
}
