using System.Runtime.Serialization;

namespace DidactEngine.Plugins
{
    [Serializable]
    public class PluginConfigurationException : Exception
    {
        public PluginConfigurationException()
        {
        }

        public PluginConfigurationException(string message) : base(message)
        {
        }

        public PluginConfigurationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PluginConfigurationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
