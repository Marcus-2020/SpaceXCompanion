using Newtonsoft.Json;

namespace SpaceXCompanion.API.Models.Launches.Social;

public class Reddit
{
    [JsonProperty("campaign")]
    public string Campaign { get; set; }

    [JsonProperty("launch")]
    public string Launch { get; set; }

    [JsonProperty("media")]
    public string Media { get; set; }

    [JsonProperty("recovery")]
    public object Recovery { get; set; }
}