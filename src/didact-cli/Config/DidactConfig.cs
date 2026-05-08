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
            public Database? Database { get; set; }

            public Engine? Engine { get; set; }
    
            public UI? UI { get; set; }

            public string? EncryptionKey { get; set; }

            public string? LicenseKey { get; set; }
        }

        public class Database
        {
            public string Provider { get; set; } = null!;

            public string ConnectionString { get; set; } = null!;
        }

        public class Engine
        {
            public string? Name { get; set; }
        }

        public class UI
        {
            public string EngineBaseUrl { get; set; } = null!;
        }
    }
}
