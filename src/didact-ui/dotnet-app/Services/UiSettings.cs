using System.Text.Json.Serialization;

namespace DidactUi.Services
{
    public class UiSettings
    {
        [JsonPropertyName("didactEngineBaseUrl")]
        public string DidactEngineBaseUrl { get; set; }
    }
}