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

        public static class PluginStates
        {
            public const string Loading = "Loading";
            public const string Active = "Active";
            public const string Draining = "Draining";
            public const string Unloaded = "Unloaded";
        }
    }
}
