using System;
using System.Runtime.Serialization;

namespace DidactCore.Plugins
{
    [Serializable]
    public class MultipleMatchedPluginsException : Exception
    {
        public MultipleMatchedPluginsException()
        {
        }

        public MultipleMatchedPluginsException(string message) : base(message)
        {
        }

        public MultipleMatchedPluginsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MultipleMatchedPluginsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
