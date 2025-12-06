using System;

namespace DidactCore.Flows
{
    public class FlowConfiguratorDto
    {
        public Type FlowType { get; set; } = null!;

        public IFlow? FlowInstance { get; set; } = null;

        public Exception? Exception { get; set; } = null;
    }
}
