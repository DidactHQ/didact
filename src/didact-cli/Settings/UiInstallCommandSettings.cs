using Spectre.Console.Cli;

namespace DidactCli.Settings
{
    public class UiInstallCommandSettings : CommandSettings
    {
        [CommandOption("-p|--path <PATH>")]
        public string InstallationPath { get; set; } = null!;
    }
}
