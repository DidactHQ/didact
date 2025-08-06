using System;

namespace DidactCore.Flows
{
    public interface IFlowLogger
    {
        void LogInformation(string message, params object[] args);

        void LogError(Exception ex, string message, params object[] args);
    }
}