namespace DidactPrimitives.Constants
{
    public static class FlowRunStates
    {
        public static class Scheduled
        {
            public const string Name = "Scheduled";
            public const string Description = "The FlowRun is scheduled for future enqueueing and execution.";
        }

        public static class Pending
        {
            public const string Name = "Pending";
            public const string Description = "The FlowRun has been enqueued and is awaiting imminent execution.";
        }

        public static class Running
        {
            public const string Name = "Running";
            public const string Description = "The FlowRun is currently executing.";
        }

        public static class AwaitingRetry
        {
            public const string Name = "AwaitingRetry";
            public const string Description = "The FlowRun has been enqueued for a retry execution.";
        }

        public static class Retrying
        {
            public const string Name = "Retrying";
            public const string Description = "The FlowRun is retrying execution after a failure.";
        }

        public static class Failing
        {
            public const string Name = "Failing";
            public const string Description = "The FlowRun is in the process of failing after exhausting all retry attempts.";
        }

        public static class Failed
        {
            public const string Name = "Failed";
            public const string Description = "The FlowRun has failed after exhausting all retry attempts.";
        }

        public static class Succeeded
        {
            public const string Name = "Succeeded";
            public const string Description = "The FlowRun has completed execution successfully.";
        }

        public static class Cancelled
        {
            public const string Name = "Cancelled";
            public const string Description = "The FlowRun has been cancelled.";
        }

        public static class Cancelling
        {
            public const string Name = "Cancelling";
            public const string Description = "The FlowRun is awaiting cancellation.";
        }
    }
}
