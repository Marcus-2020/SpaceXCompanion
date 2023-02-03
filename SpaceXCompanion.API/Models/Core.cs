using Newtonsoft.Json;

namespace SpaceXCompanion.API.Models;

public class Core
{
    [JsonProperty("block")]
    public int Block { get; set; }

    [JsonProperty("reuse_count")]
    public int ReuseCount { get; set; }

    [JsonProperty("rtls_attempts")]
    public int RtlsAttempts { get; set; }

    [JsonProperty("rtls_landings")]
    public int RtlsLandings { get; set; }

    [JsonProperty("asds_attempts")]
    public int AsdsAttempts { get; set; }

    [JsonProperty("asds_landings")]
    public int AsdsLandings { get; set; }

    [JsonProperty("last_update")]
    public string LastUpdate { get; set; }

    [JsonProperty("launches")]
    public List<string> Launches { get; set; }

    [JsonProperty("serial")]
    public string Serial { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }
}