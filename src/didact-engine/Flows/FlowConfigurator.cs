using DidactCore.Constants;
using DidactCore.Exceptions;
using DidactCore.Triggers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DidactCore.Flows
{
    public class FlowConfigurator : IFlowConfigurator
    {
        private readonly ILogger<FlowConfigurator> _logger;

        private readonly IFlowRepository _flowRepository;

        public string? Name { get; private set; }

        public string? Description { get; private set; }

        public string Version { get; private set; } = Defaults.DefaultFlowVersion;

        public string? TypeName { get; private set; }

        public string DefaultQueueType { get; private set; } = QueueTypes.HyperQueue;

        public string DefaultQueueName { get; private set; } = Defaults.DefaultQueueName;

        public ICollection<ICronScheduleTrigger> CronScheduleTriggers { get; private set; } = [];

        public FlowConfigurator(ILogger<FlowConfigurator> logger, IFlowRepository flowRepository)
        {
            _logger = logger;
            _flowRepository = flowRepository;
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

        public IFlowConfigurator WithTypeName(string typeName)
        {
            TypeName = typeName;
            return this;
        }

        public IFlowConfigurator WithDefaultQueue(string queueType, string queueName = Defaults.DefaultQueueName)
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

        public async Task SaveConfigurationsAsync()
        {
            try
            {
                _logger.LogInformation("Saving the Flow configurations to persistent storage...");
                await _flowRepository.SaveConfigurationsAsync(this).ConfigureAwait(false);
                _logger.LogInformation("Flow configurations saved successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Flow configurations were unable to be saved successfully. See inner exception: {ex}", ex);
                var saveFlowConfigurationsException = new SaveFlowConfigurationsException("Flow configurations were unable to be saved successfully. See inner exception.", ex);
                throw saveFlowConfigurationsException;
            }
        }
    }
}
