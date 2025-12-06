namespace DidactEngine.Constants
{
    public static class EngineConstants
    {
        public const string ApiBasePath = "/api";

        public static class CorsPolicyNames
        {
            public const string Development = "DevelopmentCors";
            public const string Staging = "StagingCors";
            public const string Production = "ProductionCors";
        }

        public static class ModuleNames
        {
            public const string Plugins = "Plugins";
            public const string Scheduler = "Scheduler";
            public const string Workers = "Workers";
            public const string Licensing = "Licensing";
            public const string EngineLogger = "Engine Logger";
            public const string FlowRunLogger = "FlowRun Logger";
        }

        public static class PluginStates
        {
            public const string Loading = "Loading";
            public const string Active = "Active";
            public const string Draining = "Draining";
            public const string Unloaded = "Unloaded";
        }

        public static class ThreadpoolShutdownModes
        {
            public const string Immediate = "Immediate";
            public const string Drain = "Drain";
        }
    }
}
