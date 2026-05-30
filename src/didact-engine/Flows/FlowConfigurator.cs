using DidactCore.Flows;
using DidactCore.Schedules;
using DidactDomain.Schedules;
using DidactPrimitives.Constants;

namespace DidactEngine.Flows
{
    public class FlowConfigurator : IFlowConfigurator
    {
        private readonly IScheduleBuilderFactory _scheduleBuilderFactory;
        private readonly ICronScheduleBuilderFactory _cronScheduleBuilderFactory;
        private readonly IOneTimeScheduleBuilderFactory _oneTimeScheduleBuilderFactory;

        public string Name { get; private set; } = null!;

        public string? Description { get; private set; }

        public string Version { get; private set; } = DidactCore.Constants.Defaults.DefaultFlowVersion;

        public IDictionary<string, IScheduleBuilder> ScheduleBuilders { get; private set; } = new Dictionary<string, IScheduleBuilder>();

        public string DefaultQueueType { get; private set; } = QueueTypes.HyperQueue;

        public string DefaultQueueName { get; private set; } = DidactCore.Constants.Defaults.DefaultQueueName;

        public FlowConfigurator(IScheduleBuilderFactory scheduleBuilderFactory, ICronScheduleBuilderFactory cronScheduleBuilderFactory,
            IOneTimeScheduleBuilderFactory oneTimeScheduleBuilderFactory)
        {
            _scheduleBuilderFactory = scheduleBuilderFactory ?? throw new ArgumentNullException(nameof(scheduleBuilderFactory));
            _cronScheduleBuilderFactory = cronScheduleBuilderFactory ?? throw new ArgumentNullException(nameof(cronScheduleBuilderFactory));
            _oneTimeScheduleBuilderFactory = oneTimeScheduleBuilderFactory ?? throw new ArgumentNullException(nameof(oneTimeScheduleBuilderFactory));
        }

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

        public IFlowConfigurator UseCronSchedule(string name, string cronExpression)
        {
            var iScheduleBuilder = _scheduleBuilderFactory.Create()
                .AsScheduleType(ScheduleTypes.Cron)
                .WithName(name)
                .WithCronExpression(cronExpression);

            if (!ScheduleBuilders.TryAdd(name, iScheduleBuilder))
                throw new ArgumentException($"A schedule named '{iScheduleBuilder.Name}' already exists.");

            return this;
        }

        public IFlowConfigurator UseCronSchedule(Action<ICronScheduleBuilder> configure)
        {
            // Validate action
            ArgumentNullException.ThrowIfNull(configure);

            // Execute action
            var iCronScheduleBuilder = _cronScheduleBuilderFactory.Create();
            configure(iCronScheduleBuilder);

            // Validate properties
            if (string.IsNullOrWhiteSpace(iCronScheduleBuilder.Name))
                throw new ArgumentException("Cron schedule must have a name.");

            if (string.IsNullOrWhiteSpace(iCronScheduleBuilder.CronExpression))
                throw new ArgumentException("Cron schedule must have a cron expression.");

            // Map to shared builder
            var iScheduleBuilder = _scheduleBuilderFactory.Create()
                .AsScheduleType(ScheduleTypes.Cron)
                .WithName(iCronScheduleBuilder.Name)
                .WithCronExpression(iCronScheduleBuilder.CronExpression);

            // Add to collection
            if (!ScheduleBuilders.TryAdd(iScheduleBuilder.Name, iScheduleBuilder))
                throw new ArgumentException($"A schedule named '{iScheduleBuilder.Name}' already exists.");

            return this;
        }

        public IFlowConfigurator UseOneTimeSchedule(string name, DateTime executeAt)
        {
            var iScheduleBuilder = _scheduleBuilderFactory.Create()
                .AsScheduleType(ScheduleTypes.OneTime)
                .WithName(name)
                .WithExecuteAt(executeAt);

            if (!ScheduleBuilders.TryAdd(name, iScheduleBuilder))
                throw new ArgumentException($"A schedule named '{iScheduleBuilder.Name}' already exists.");

            return this;
        }

        public IFlowConfigurator UseOneTimeSchedule(Action<IOneTimeScheduleBuilder> configure)
        {
            // Validate action
            ArgumentNullException.ThrowIfNull(configure);

            // Execute action
            var iOneTimeScheduleBuilder = _oneTimeScheduleBuilderFactory.Create();
            configure(iOneTimeScheduleBuilder);

            // Validate properties
            if (string.IsNullOrWhiteSpace(iOneTimeScheduleBuilder.Name))
                throw new ArgumentException("One-time schedule must have a name.");

            if (iOneTimeScheduleBuilder.ExecuteAt is null)
                throw new ArgumentException("One-time schedule must have an execution time.");

            var convertedDateTime = (DateTime)iOneTimeScheduleBuilder.ExecuteAt;

            // Map to shared builder
            var iScheduleBuilder = _scheduleBuilderFactory.Create()
                .AsScheduleType(ScheduleTypes.OneTime)
                .WithName(iOneTimeScheduleBuilder.Name)
                .WithExecuteAt(convertedDateTime);

            // Add to collection
            if (!ScheduleBuilders.TryAdd(iScheduleBuilder.Name, iScheduleBuilder))
                throw new ArgumentException($"A schedule named '{iScheduleBuilder.Name}' already exists.");

            return this;
        }
    }
}
