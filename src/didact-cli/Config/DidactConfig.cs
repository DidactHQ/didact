using System.Text.Json.Serialization;
using DidactCli.Constants;

namespace DidactCli.Config
{
    public class DidactConfig
    {
        [JsonPropertyName("$schema")]
        public string Schema { get; set; } = CliConstants.SchemaUrl;

        [JsonPropertyName("activeProfile")]
        public string ActiveProfile { get; set; } = string.Empty;

        [JsonPropertyName("profiles")]
        public Dictionary<string, DidactProfile> Profiles { get; set; } = [];

        public class DidactProfile
        {
            [JsonPropertyName("cli")]
            public Cli? Cli { get; set; }

            [JsonPropertyName("engine")]
            public Engine? Engine { get; set; }
    
            [JsonPropertyName("ui")]
            public Ui? Ui { get; set; }
        }

        public class Cli
        {
            [JsonPropertyName("engineBaseUrl")]
            public string? EngineBaseUrl { get; set; }
        }

        public class Engine
        {
            [JsonPropertyName("database")]
            public Database? Database { get; set; }

            [JsonPropertyName("name")]
            public string? Name { get; set; }

            [JsonPropertyName("encryptionKey")]
            public string? EncryptionKey { get; set; }
            
            [JsonPropertyName("licenseKey")]
            public string? LicenseKey { get; set; }
        }

        public class Database
        {
            [JsonPropertyName("provider")]
            public string Provider { get; set; } = null!;
            
            [JsonPropertyName("connectionString")]
            public string ConnectionString { get; set; } = null!;
        }

        public class Ui
        {
            [JsonPropertyName("engineBaseUrl")]
            public string EngineBaseUrl { get; set; } = null!;
        }
    }
}
