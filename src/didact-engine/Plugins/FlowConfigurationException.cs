using System.Runtime.Serialization;

namespace DidactEngine.Plugins
{
    [Serializable]
    public class FlowConfigurationException : Exception
    {
        public FlowConfigurationException()
        {
        }

        public FlowConfigurationException(string message) : base(message)
        {
        }

        public FlowConfigurationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FlowConfigurationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
