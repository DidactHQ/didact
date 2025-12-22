using DidactCore.Flows;

namespace DidactEngine.Plugins
{
    public interface IPluginFlowConfigurationContext
    {
        public Type FlowType { get; set; }

        public IFlowConfigurationContext FlowConfigurationContext { get; set; }

        public IFlow? FlowInstance { get; set; }
    }
}
