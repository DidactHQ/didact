using DidactCore.Flows;
using DidactCore.Triggers;
using DidactPrimitives.Constants;

namespace DidactEngine.Flows
{
    public class FlowConfigurator : IFlowConfigurator
    {
        public string? Name { get; private set; }

        public string? Description { get; private set; }

        public string Version { get; private set; } = DidactCore.Constants.Defaults.DefaultFlowVersion;

        public string DefaultQueueType { get; private set; } = QueueTypes.HyperQueue;

        public string DefaultQueueName { get; private set; } = DidactCore.Constants.Defaults.DefaultQueueName;

        public ICollection<ICronScheduleTrigger> CronScheduleTriggers { get; private set; } = [];

        public IFlowConfigurator WithName(string name)
        {
            Name = name;
            return this;
        }

        public IFlowConfigurator WithDescription(string description)
        {
            Description = description;
            return this;
        }

        public IFlowConfigurator AsVersion(string version)
        {
            Version = version;
            return this;
        }

        public IFlowConfigurator WithDefaultQueue(string queueType, string queueName = DidactCore.Constants.Defaults.DefaultQueueName)
        {
            DefaultQueueType = queueType;
            DefaultQueueName = queueName;
            return this;
        }

        public IFlowConfigurator WithCronScheduleTrigger(ICronScheduleTrigger cronScheduleTrigger)
        {
            CronScheduleTriggers.Add(cronScheduleTrigger);
            return this;
        }
    }
}
