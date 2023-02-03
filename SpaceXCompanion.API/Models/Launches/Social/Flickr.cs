using Newtonsoft.Json;

namespace SpaceXCompanion.API.Models.Launches.Social;

public class Flickr
{
    [JsonProperty("small")]
    public List<object> Small { get; set; }

    [JsonProperty("original")]
    public List<string> Original { get; set; }
}