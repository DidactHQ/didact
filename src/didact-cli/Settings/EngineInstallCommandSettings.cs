using Spectre.Console.Cli;

namespace DidactCli.Settings
{
    public class EngineInstallCommandSettings : CommandSettings
    {
        [CommandOption("-p|--path <PATH>")]
        // Add default path?
        public string InstallationPath { get; set; } = null!;
    }
}