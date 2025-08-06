using DidactCli.Services;
using DidactCli.Settings;
using Microsoft.Extensions.Logging;
using Spectre.Console;
using Spectre.Console.Cli;

namespace DidactCli.Commands
{
    public class EngineInstallCommand : Command<EngineInstallCommandSettings>
    {
        private readonly ILogger<EngineInstallCommand> _logger;
        private readonly AppSettings _appSettings;

        public EngineInstallCommand(ILogger<EngineInstallCommand> logger, AppSettings appSettings)
        {
            _logger = logger;
            _appSettings = appSettings;
        }

        public override int Execute(CommandContext context, EngineInstallCommandSettings settings)
        {
            _logger.LogInformation("Reading path...");
            _logger.LogInformation(_appSettings.TestSetting);
            AnsiConsole.WriteLine(settings.InstallationPath);
            return 0;
        }
    }
}
