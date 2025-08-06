using DidactCore.Constants;
using System;

namespace DidactCore.Flows
{
    public class FlowConfiguratorDto
    {
        public Type FlowType { get; set; } = null!;

        public IFlow? FlowInstance { get; set; } = null;

        public string State { get; set; } = FlowConfiguratorStates.FlowConfigurationUninitialized;

        public Exception? Exception { get; set; } = null;
    }
}
