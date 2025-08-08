namespace DidactServices
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
            public const string DidactUiSettings = "uisettings.json";
            public const string DidactEngineSettings = "enginesettings.json";
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
    }
}