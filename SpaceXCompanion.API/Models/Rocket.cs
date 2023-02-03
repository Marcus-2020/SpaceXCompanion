using Newtonsoft.Json;

namespace SpaceXCompanion.API.Models;

public class Rocket
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("fullName")]
    public object FullName { get; set; }

    [JsonProperty("status")]
    public object Status { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("locality")]
    public object Locality { get; set; }

    [JsonProperty("region")]
    public object Region { get; set; }

    [JsonProperty("latitude")]
    public int Latitude { get; set; }

    [JsonProperty("longitude")]
    public int Longitude { get; set; }

    [JsonProperty("landingAttempts")]
    public int LandingAttempts { get; set; }

    [JsonProperty("landingSuccesses")]
    public int LandingSuccesses { get; set; }

    [JsonProperty("wikipedia")]
    public string Wikipedia { get; set; }

    [JsonProperty("details")]
    public object Details { get; set; }

    [JsonProperty("launches")]
    public object Launches { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }
}