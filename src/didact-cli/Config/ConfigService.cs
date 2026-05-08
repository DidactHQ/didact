using DidactCli.Constants;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace DidactCli.Config
{
    public class ConfigService
    {
        private readonly ILogger<ConfigService> _logger;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly IOptions<DidactConfig> _config;

        public ConfigService(ILogger<ConfigService> logger, IOptions<DidactConfig> config)
        {
            _logger = logger;
            _config = config;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true
            };
        }

        public static string GetAppDirectory()
        {
            var exePath = Environment.ProcessPath
                ?? throw new Exception("Could not determine application directory.");
            return Path.GetDirectoryName(exePath)
                ?? throw new Exception("Could not determine application directory.");
        }

        public static string GetAppDataDirectory()
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                CliConstants.CliName);
        }

        public static string GetConfigPath()
        {
            var appDirectory = GetAppDirectory();
            var localPath = Path.Combine(
                appDirectory,
                DidactDomain.Constants.Constants.ConfigFileName);

            if (File.Exists(localPath))
                return localPath;

            var appDataDirectory = GetAppDataDirectory();
            var appDataPath = Path.Combine(appDataDirectory, DidactDomain.Constants.Constants.ConfigFileName);

            if (File.Exists(appDataPath))
                return appDataPath;

            throw new Exception(
                "Could not find a config file in either the application directory or the AppData directory. Please initialize a config file."
                );
        }

        public DidactConfig.DidactProfile GetActiveProfileConfig()
        {
            var configExists = _config.Value.Profiles.TryGetValue(_config.Value.ActiveProfile, out var profileConfig);
            if (!configExists)
                throw new Exception("An active config profile has not been selected. Please set an active config profile.");

            if (profileConfig is null)
                throw new Exception("The selected config profile is NULL. Please set the profile's config values.");

            return profileConfig;
        }

        public void SetActiveProfile(string profileName)
        {
            var configPath = GetConfigPath();
            var configJson = File.ReadAllText(configPath);
            var config = JsonSerializer.Deserialize<DidactConfig>(configJson)
                ?? throw new Exception("Could not read config file. Aborting operation.");

            var profileExists = config.Profiles.TryGetValue(profileName, out _);
            if (!profileExists)
                throw new Exception($"The profile name {profileName} does not exist. Aborting operation.");

            config.ActiveProfile = profileName;
            var updatedConfigJson = JsonSerializer.Serialize(config, _jsonSerializerOptions);
            File.WriteAllText(configPath, updatedConfigJson);
            _logger.LogInformation("Active profile set to {pn} successfully.", profileName);
        }

        public void InitProfile(string profileName)
        {
            var configPath = GetConfigPath();
            var configJson = File.ReadAllText(configPath);
            var config = JsonSerializer.Deserialize<DidactConfig>(configJson)
                ?? throw new Exception("Could not read config file. Aborting operation.");

            // Check if profile already exists.
            var profileExists = config.Profiles.TryGetValue(profileName, out _);
            if (profileExists)
                throw new Exception($"The profile name {profileName} already exists. Aborting operation.");

            config.Profiles.TryAdd(profileName, new DidactConfig.DidactProfile());
            var updatedJsonConfig = JsonSerializer.Serialize(config, _jsonSerializerOptions);
            File.WriteAllText(configPath, updatedJsonConfig);
            _logger.LogInformation("Profile initialized successfully.");
        }

        public void InspectConfig()
        {
            var configPath = GetConfigPath();
            var configJson = File.ReadAllText(configPath);
            _logger.LogInformation("Config file values:");
            _logger.LogInformation("{json}", configJson);
            _logger.LogInformation("Config file location: {path}", configPath);
        }

        public void InitConfig()
        {
            var appDirectoryPath = GetAppDirectory();
            var appDirectoryConfigPath = Path.Combine(appDirectoryPath, DidactDomain.Constants.Constants.ConfigFileName);
            if (File.Exists(appDirectoryConfigPath))
                throw new Exception($"A config file already exists at {appDirectoryConfigPath}.");

            var appDataDirectoryPath = GetAppDataDirectory();
            var appDataDirectoryConfigPath = Path.Combine(appDataDirectoryPath, DidactDomain.Constants.Constants.ConfigFileName);
            if (File.Exists(appDataDirectoryConfigPath))
                throw new Exception($"A config file already exists at {appDataDirectoryConfigPath}.");

            var didactConfig = new DidactConfig();
            var initialJsonConfig = JsonSerializer.Serialize(didactConfig, _jsonSerializerOptions);
            File.WriteAllText(appDirectoryConfigPath, initialJsonConfig);
            _logger.LogInformation("Config file initialized successfully at {path}.", appDirectoryConfigPath);
        }

        private void WriteInMemoryConfigBackToFile()
        {
            var updatedConfig = JsonSerializer.Serialize(_config.Value, _jsonSerializerOptions);
            var configPath = GetConfigPath();
            File.WriteAllText(configPath, updatedConfig);
        }
    }
}
