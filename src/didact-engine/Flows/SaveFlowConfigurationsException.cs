using System;
using System.Runtime.Serialization;

namespace DidactCore.Exceptions
{
    [Serializable]
    public class SaveFlowConfigurationsException : Exception
    {
        public SaveFlowConfigurationsException()
        {
        }

        public SaveFlowConfigurationsException(string message) : base(message)
        {
        }

        public SaveFlowConfigurationsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SaveFlowConfigurationsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
