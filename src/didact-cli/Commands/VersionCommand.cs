using DidactCli.Settings;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Reflection;

namespace DidactCli.Commands
{
    public class VersionCommand : Command<VersionCommandSettings>
    {
        public override int Execute(CommandContext context, VersionCommandSettings settings)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            AnsiConsole.Write(version);
            return 0;
        }
    }
}