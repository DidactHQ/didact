namespace DidactDomain.Constants
{
    public static class Constants
    {
        public static class ApplicationNames
        {
            public const string DidactUi = "Didact UI";
            public const string DidactEngine = "Didact Engine";
            public const string DidactCli = "Didact CLI";
        }

        public static class ApplicationConfigurationFileNames
        {
            public const string DidactCli = "cliconfig.json";
            public const string DidactUi = "uiconfig.json";
            public const string DidactEngine = "engineconfig.json";
        }

        public static class Defaults
        {
            public const string DefaultBuildEnvironment = BuildEnvironments.Production;
        }

        public static class Keys
        {
            public const string BuildEnvironment = "DIDACT_BUILD_ENVIRONMENT";
        }

        public static class BuildEnvironments
        {
            public const string Development = "Development";
            public const string Staging = "Staging";
            public const string Production = "Production";
        }

        public static class DatabaseProviders
        {
            public const string SqlServer = "SqlServer";
            public const string Postgres = "Postgres";
        }
    }
}