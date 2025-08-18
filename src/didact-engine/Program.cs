using DidactEngine.Constants;
using DidactEngine.Services;
using DidactServices.Constants;
using DidactServices.DataModel.Contexts;
using DidactServices.Environments;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.OpenApi.Models;
using Spectre.Console;
using System.Diagnostics;
using System.Reflection;

#region App metadata

var applicationName = Constants.ApplicationNames.DidactEngine;
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
var hostAppEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var appsettingsEnvironment = EnvironmentService.GetDynamicHostAppEnvironment(buildEnvironment, hostAppEnvironment);

var settingsFilename = Constants.ApplicationConfigurationFileNames.DidactEngineSettings;
var apiBasePath = EngineConstants.ApiBasePath;
var urls = Environment.GetEnvironmentVariable("ASPNETCORE_URLS");
var urlsSplit = string.IsNullOrEmpty(urls) ? [] : urls.Split(';');
var consoleUrls = string.Empty;
foreach (var url in urlsSplit)
{
    var separator = string.IsNullOrEmpty(consoleUrls) ? string.Empty : Environment.NewLine;
    consoleUrls = string.Concat(consoleUrls, separator, url, apiBasePath);
}

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
if (!string.IsNullOrEmpty(consoleUrls))
    table.AddRow("API", consoleUrls);
table.BorderStyle(new Style(themeColor));

var padder = new Padder(table).PadBottom(1).PadTop(0);

var grid = new Grid();
grid.AddColumn();
grid.AddRow(padder);

AnsiConsole.Write(grid);

#endregion

var builder = WebApplication.CreateBuilder(args);

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

#region Read enginesettings.json as a runtime IConfiguration.

// Get the real EXE directory
var exePath = Process.GetCurrentProcess().MainModule?.FileName;
var exeDirectory = Path.GetDirectoryName(exePath)!;

// Define the path to enginesettings.json
var engineSettingsPath = Path.Combine(exeDirectory, settingsFilename);

// Build configuration
var engineSettingsIConfiguration = new ConfigurationBuilder()
    .SetBasePath(exeDirectory)
    .AddJsonFile(engineSettingsPath, optional: true, reloadOnChange: true)
    .Build();

var engineSettings = new EngineSettings();
engineSettingsIConfiguration.Bind(engineSettings);
builder.Services.AddSingleton(engineSettings);

#endregion

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: EngineConstants.CorsPolicyNames.Development,
        policy =>
        {
            policy.WithOrigins("http://localhost:8080");
            policy.AllowAnyMethod();
            policy.AllowAnyHeader();
            policy.AllowCredentials();
        });
});

#region Configure DbContext and Gateway.

var connStringFactory = (string name) => new SqlConnectionStringBuilder(
    builder.Configuration.GetConnectionString(name))
{
    ApplicationName = "Didact",
    PersistSecurityInfo = true,
    MultipleActiveResultSets = true,
    WorkstationID = Environment.MachineName,
    TrustServerCertificate = true
}.ConnectionString;

builder.Services.AddDbContext<DidactDbContext>(
    (sp, opt) =>
    {
        opt.UseMemoryCache(sp.GetRequiredService<IMemoryCache>());
        opt.UseSqlServer(connStringFactory("Didact"), opt => opt.CommandTimeout(110));
        if (builder.Configuration.GetValue<bool?>("EnableSensitiveDataLogging").GetValueOrDefault())
        {
            opt.EnableDetailedErrors();
            opt.EnableSensitiveDataLogging();
        }
    });

#endregion Configure DbContext and Gateway.

builder.Services.AddControllers();
builder.Services.AddMemoryCache();

// Register Swagger
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
string swaggerVersion = "v1";
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc(swaggerVersion, new OpenApiInfo
    {
        Version = swaggerVersion,
        Title = "Didact REST API",
        Description = "The central REST API of the Didact Engine."
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddEndpointsApiExplorer();

// Register BackgroundServices
//builder.Services.AddHostedService<WorkerBackgroundService>();
// Register Flow helper services from DidactCore.
//builder.Services.AddSingleton<IFlowExecutor, FlowExecutor>();
// Register repositories from DidactCore.
//builder.Services.AddScoped<IFlowRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors(EngineConstants.CorsPolicyNames.Development);
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();