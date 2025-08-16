using DidactCore.Entities;
using DidactCore.Plugins;

namespace DidactCore.Flows
{
    public class FlowRunDto
    {
        public long FlowRunId { get; set; }

        public int TimeoutSeconds { get; set; }

        public string FlowTypeName { get; set; } = null!;

        public string? StringifiedJsonPayload { get; set; }

        public FlowRun FlowRun { get; set; } = null!;

        public PluginExecutionVersion PluginExecutionVersion { get; set; } = null!;

        public Flow Flow { get; set; } = null!;

        public IFlow? FlowInstance { get; set; }
    }
}
