using DidactCli.Services;
using DidactCli.Settings;
using Microsoft.Extensions.Logging;
using Spectre.Console;
using Spectre.Console.Cli;

namespace DidactCli.Commands
{
    public class UiInstallCommand : Command<UiInstallCommandSettings>
    {
        private readonly ILogger<UiInstallCommand> _logger;
        private readonly AppSettings _appSettings;

        public UiInstallCommand(ILogger<UiInstallCommand> logger, AppSettings appSettings)
        {
            _logger = logger;
            _appSettings = appSettings;
        }

        public override int Execute(CommandContext context, UiInstallCommandSettings settings)
        {
            _logger.LogInformation("Reading path...");
            _logger.LogInformation(_appSettings.TestSetting);
            AnsiConsole.WriteLine(settings.InstallationPath);
            return 0;
        }
    }
}
