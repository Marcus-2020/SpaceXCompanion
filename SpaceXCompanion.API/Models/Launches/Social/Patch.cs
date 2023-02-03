using Newtonsoft.Json;

namespace SpaceXCompanion.API.Models.Launches.Social;

public class Patch
{
    [JsonProperty("small")]
    public string Small { get; set; }

    [JsonProperty("large")]
    public string Large { get; set; }
}