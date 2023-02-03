using Newtonsoft.Json;

namespace SpaceXCompanion.API.Models;

public class Landpad
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("full_name")]
    public string FullName { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("locality")]
    public string Locality { get; set; }

    [JsonProperty("region")]
    public string Region { get; set; }

    [JsonProperty("latitude")]
    public double Latitude { get; set; }

    [JsonProperty("longitude")]
    public double Longitude { get; set; }

    [JsonProperty("landing_attempts")]
    public int LandingAttempts { get; set; }

    [JsonProperty("landing_successes")]
    public int LandingSuccesses { get; set; }

    [JsonProperty("wikipedia")]
    public string Wikipedia { get; set; }

    [JsonProperty("details")]
    public string Details { get; set; }

    [JsonProperty("launches")]
    public List<string> Launches { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }
}