using DidactCli.Settings;
using Spectre.Console.Cli;

namespace DidactCli.Commands
{
    public class TestCommand : Command<TestCommandSettings>
    {
        public override int Execute(CommandContext context, TestCommandSettings settings)
        {
            // Omitted
            return 0;
        }
    }
}
