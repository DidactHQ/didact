namespace DidactEngine.Constants
{
    public static class Defaults
    {
        public const decimal DefaultThreadFactor = 1;

        public static class DefaultModuleIntervalDelays
        {
            public const int Plugins = 120000;
            public const int Scheduler = 5000;
            public const int Workers = 0;
            public const int Licensing = 1800000;
            public const int EngineLogger = 0;
            public const int FlowRunLogger = 0;
        }

        public const int DefaultWorkersServiceDequeueIntervalDelay = 5000;
        public const int FlowRunCancellationPollingInterval = 60000;
    }
}
