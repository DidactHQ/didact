// See https://aka.ms/new-console-template for more information
using DidactCli.Commands;
using DidactCli.Services;
using DidactServices.Constants;
using DidactServices.Environments;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Reflection;

#region App metadata

var applicationName = Constants.ApplicationNames.DidactCli;
var themeColor = new Color(249, 115, 22);
var assembly = Assembly.GetExecutingAssembly();
var assemblyName = assembly.GetName().Name;

/* There is a distinction between the normal dotnet environment designation and the Didact build environment.
 * If the build environment is Production, then we assume this app is a tested and released version,
 * meaning end users should ONLY use production settings for Didact Platform.
 * However, if the build environment is NOT Production, then we assume this app is currently under development by Didact's maintainer,
 * meaning that we DO want to use the Development or Staging environment settings.
 */
var buildEnvironment = EnvironmentService.GetBuildEnvironment();
var hostAppEnvironment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");
var appsettingsEnvironment = EnvironmentService.GetDynamicHostAppEnvironment(buildEnvironment, hostAppEnvironment);

#endregion

#region Configure Spectre Console decorator.

var figletText = new FigletText(applicationName).LeftJustified().Color(themeColor);
AnsiConsole.Write(figletText);

// Create a table
var table = new Table().HideHeaders();
table.AddColumn("");
table.AddColumn(new TableColumn(""));
table.AddRow("Name", applicationName);
table.AddRow("Version", assembly.GetName().Version!.ToString());
table.AddRow("Build Environment", buildEnvironment);
table.AddRow("Start time", DateTime.UtcNow.ToString("O"));
table.AddRow("Process Id", Environment.ProcessId.ToString());
table.AddRow("OS version", Environment.OSVersion.ToString());
table.AddRow("Machine name", Environment.MachineName);
table.AddRow("Username", Environment.UserName);
table.AddRow("Environment", hostAppEnvironment ?? string.Empty);
table.BorderStyle(new Style(themeColor));

var padder = new Padder(table).PadBottom(1).PadTop(0);

var grid = new Grid();
grid.AddColumn();
grid.AddRow(padder);

AnsiConsole.Write(grid);

#endregion

#region Read appsettings.json as an embedded resource.

// Support multi-environment appsettings files.
var resourceFileName = string.IsNullOrEmpty(appsettingsEnvironment)
    ? $"{assemblyName}.appsettings.json"
    : $"{assemblyName}.appsettings.{appsettingsEnvironment}.json";

// Fetch the appsettings.json file as an embedded resource.
var stream = assembly.GetManifestResourceStream(resourceFileName);
var reader = new StreamReader(stream!);
var json = reader.ReadToEnd();

// Create a new IConfiguration.
var iConfiguration = new ConfigurationBuilder()
    .AddJsonStream(new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json)))
    .Build();

#endregion

#region Setup dependency injection and other bootstrapping utilities.

// Bind to the appsettings class.
var appSettings = new AppSettings();
iConfiguration.Bind(appSettings);

var services = new ServiceCollection();
services.AddSingleton<IConfiguration>(iConfiguration);
services.AddSingleton(appSettings);
services.AddLogging(configure =>
{
    configure.AddConsole();
});
var registrar = new TypeRegistrar(services);
var app = new CommandApp(registrar);

#endregion

app.Configure(config =>
{
    config.SetApplicationName("Didact Cli");
    config.AddCommand<VersionCommand>("version")
        .WithDescription("The version of Didact Cli.");

    config.AddBranch("engine", engine =>
    {
        engine.AddCommand<EngineInstallCommand>("install") // run "didact engine set" after installation? --set-after-install true ?
            .WithDescription("Installs Didact Engine to the target location.");
        engine.AddCommand<TestCommand>("set")
            .WithDescription("Sets the target Didact Engine.");
        engine.AddCommand<TestCommand>("get")
            .WithDescription("Gets the target Didact Engine.");
        engine.AddBranch("config", config =>
        {
            config.AddCommand<TestCommand>("generate") // --open true option for autoopening config file. // --with-file "" option for using existing config file.
                .WithDescription("Generates a new runtime environment variables file for Didact Engine.");
            config.AddCommand<TestCommand>("get")
                .WithDescription("Gets the runtime environment variables file for Didact Engine.");
        });
    });

    config.AddBranch("ui", ui =>
    {
        ui.AddCommand<UiInstallCommand>("install")
            .WithDescription("Installs Didact UI to the target location.");
        ui.AddCommand<TestCommand>("set")
            .WithDescription("Sets the target Didact UI.");
        ui.AddCommand<TestCommand>("get")
            .WithDescription("Gets the target Didact UI.");
        ui.AddBranch("config", config =>
        {
            config.AddCommand<TestCommand>("generate") // --open true option for autoopening config file.
                .WithDescription("Generates a new runtime environment variables file for Didact UI.");
            config.AddCommand<TestCommand>("get")
                .WithDescription("Gets the runtime environment variables file for Didact UI.");
        });
    });

    config.AddBranch("license", license =>
    {
        license.AddCommand<TestCommand>("set")
            .WithDescription("Sets the Didact license key.");
        license.AddCommand<TestCommand>("get")
            .WithDescription("Gets the Didact license key.");
        license.AddCommand<TestCommand>("authenticate")
            .WithDescription("Authenticates the Didact license key.");
        license.AddCommand<TestCommand>("validate")
            .WithDescription("Validates the Didact license key.");
    });

    config.AddBranch("library", library =>
    {
        library.AddCommand<TestCommand>("list")
            .WithDescription("Lists the registered Didact flow libraries.");
        library.AddCommand<TestCommand>("add")
            .WithDescription("Adds a Didact flow library to the registry.");
        library.AddCommand<TestCommand>("remove")
            .WithDescription("Removes a Didact flow library to the registry.");
        library.AddCommand<TestCommand>("deploy")
            .WithDescription("Deploys all flow libraries in the registry.");
    });
});

return app.Run(args);