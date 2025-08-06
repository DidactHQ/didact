namespace DidactCli.Services
{
    public class AppSettings
    {
        public string TestSetting { get; set; }

        public DidactEngine DidactEngine { get; set; }

        public DidactUi DidactUi { get; set; }
    }

    public class DidactEngine
    {
        public string RuntimeEnvironmentVariablesFileName { get; set; }
    }

    public class DidactUi
    {
        public string RuntimeEnvironmentVariablesFileName { get; set; }
    }
}