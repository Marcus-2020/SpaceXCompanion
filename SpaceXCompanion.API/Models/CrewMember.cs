using Newtonsoft.Json;

namespace SpaceXCompanion.API.Models;

public class CrewMember
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("agency")]
    public string Agency { get; set; }

    [JsonProperty("image")]
    public string Image { get; set; }

    [JsonProperty("wikipedia")]
    public string Wikipedia { get; set; }

    [JsonProperty("launches")]
    public List<string> Launches { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }
}