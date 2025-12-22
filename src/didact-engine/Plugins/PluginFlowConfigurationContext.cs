using DidactCore.Flows;

namespace DidactEngine.Plugins
{
    public class PluginFlowConfigurationContext : IPluginFlowConfigurationContext
    {
        public Type FlowType { get; set; }

        public IFlowConfigurationContext FlowConfigurationContext { get; set; }

        public IFlow? FlowInstance { get; set; }

        public PluginFlowConfigurationContext(Type flowType, IFlowConfigurationContext flowConfigurationContext, IFlow? flowInstance)
        {
            FlowType = flowType;
            FlowConfigurationContext = flowConfigurationContext;
            FlowInstance = flowInstance;
        }
    }
}
