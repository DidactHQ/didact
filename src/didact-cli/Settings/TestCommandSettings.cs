using Spectre.Console.Cli;

namespace DidactCli.Settings
{
    public class TestCommandSettings : CommandSettings
    {
        [CommandArgument(0, "[abcd]")]
        public string Version { get; set; }
    }
}
