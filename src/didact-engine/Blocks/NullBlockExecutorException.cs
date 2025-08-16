using System;
using System.Runtime.Serialization;

namespace DidactCore.Exceptions
{
    [Serializable]
    public class NullBlockExecutorException : Exception
    {
        public NullBlockExecutorException()
        {
        }

        public NullBlockExecutorException(string message) : base(message)
        {
        }

        public NullBlockExecutorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NullBlockExecutorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
