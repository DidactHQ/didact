using System;
using System.Runtime.Serialization;

namespace DidactEngine.Flows
{
    [Serializable]
    public class FlowTypeNotFoundException : Exception
    {
        public FlowTypeNotFoundException()
        {
        }

        public FlowTypeNotFoundException(string message) : base(message)
        {
        }

        public FlowTypeNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FlowTypeNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
