using Newtonsoft.Json;

namespace SkylineVUpdater.Classes
{
    public class UpdateJSON
    {
        [JsonProperty("version")]
        public string? Version { get; set; }

        [JsonProperty("hashList")]
        public Dictionary<string, string>? Files { get; set; }
    }
}