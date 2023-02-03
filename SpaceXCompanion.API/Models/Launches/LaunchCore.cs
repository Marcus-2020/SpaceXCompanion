using Newtonsoft.Json;

namespace SpaceXCompanion.API.Models.Launches;

public class LaunchCore
{
    [JsonProperty("core")]
    public string CoreId { get; set; }

    [JsonProperty("flight")]
    public int? Flight { get; set; }

    [JsonProperty("gridfins")]
    public bool? Gridfins { get; set; }

    [JsonProperty("legs")]
    public bool? Legs { get; set; }

    [JsonProperty("reused")]
    public bool? Reused { get; set; }

    [JsonProperty("landing_attempt")]
    public bool? LandingAttempt { get; set; }

    [JsonProperty("landing_success")]
    public bool? LandingSuccess { get; set; }

    [JsonProperty("landing_type")]
    public string LandingType { get; set; }

    [JsonProperty("landpad")]
    public string Landpad { get; set; }
}