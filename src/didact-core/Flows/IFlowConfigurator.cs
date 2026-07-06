using DidactCore.Constants;
using DidactCore.Schedules;
using System;
using System.Collections.Generic;

namespace DidactCore.Flows
{
    /// <summary>
    /// <para>A helper interface that configures Flow metadata.</para>
    /// <para>This interface and its implementations need to be registered as a transient dependency in Didact Engine.</para>
    /// </summary>
    public interface IFlowConfigurator
    {
        /// <summary>
        /// The Flow's name. Flow names must be unique per Environment.
        /// If name is null, then the Flow's TypeName will be used in its place.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The Flow's description.
        /// </summary>
        string? Description { get; }

        /// <summary>
        /// The Flow's version.
        /// </summary>
        string Version { get; }

        /// <summary>
        /// The default delay that should be applied to a FlowRun of this Flow.
        /// </summary>
        long DeferExecutionSeconds { get; }

        IDictionary<string, IScheduleBuilder> ScheduleBuilders { get; }

        /// <summary>
        /// The designated queue type that the Flow will execute against.
        /// </summary>
        string DefaultQueueType { get; }

        /// <summary>
        /// The designated queue that the Flow will execute against.
        /// </summary>
        string DefaultQueueName { get; }

        /// <summary>
        /// Sets the Flow name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IFlowConfigurator WithName(string name);

        /// <summary>
        /// Sets the Flow description.
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        IFlowConfigurator WithDescription(string description);

        /// <summary>
        /// Sets the Flow version.
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        IFlowConfigurator AsVersion(string version);

        /// <summary>
        /// Sets the Flow to execute for a specific queue type and queue.
        /// </summary>
        /// <param name="queueType"></param>
        /// <param name="queueName"></param>
        /// <returns></returns>
        IFlowConfigurator WithDefaultQueue(string queueType, string queueName = Defaults.DefaultQueueName);

        IFlowConfigurator DeferExecutionBy(TimeSpan deferBy);

        IFlowConfigurator UseCronSchedule(string name, string cronExpression);

        IFlowConfigurator UseCronSchedule(Action<ICronScheduleBuilder> configure);

        IFlowConfigurator UseOneTimeSchedule(string name, DateTime executeAt);

        IFlowConfigurator UseOneTimeSchedule(Action<IOneTimeScheduleBuilder> configure);

        IFlowConfigurator WithRetryPolicy(Action<IRetryPolicyBuilder> configure);

        IFlowConfigurator WithoutRetries();
    }
}
