using System;
using System.Runtime.Serialization;

namespace DidactCore.Plugins
{
    [Serializable]
    public class NoMatchedPluginException : Exception
    {
        public NoMatchedPluginException()
        {
        }

        public NoMatchedPluginException(string message) : base(message)
        {
        }

        public NoMatchedPluginException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoMatchedPluginException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
