using Newtonsoft.Json;
using SpaceXCompanion.API.Models.Launches.Social;

namespace SpaceXCompanion.API.Models.Launches;

public class Launch
{
    [JsonProperty("fairings")]
    public object Fairings { get; set; }

    [JsonProperty("links")]
    public Links Links { get; set; }

    private DateTime _staticFireDateUtc;
    [JsonProperty("static_fire_date_utc")]
    public DateTime? StaticFireDateUtc
    {
        get => _staticFireDateUtc;
        set => _staticFireDateUtc = value ?? DateTime.MinValue;
    }

    [JsonProperty("static_fire_date_unix")]
    public int? StaticFireDateUnix { get; set; }

    [JsonProperty("tdb")]
    public bool? Tdb { get; set; }

    [JsonProperty("net")]
    public bool? Net { get; set; }

    [JsonProperty("window")]
    public int? Window { get; set; }

    [JsonProperty("rocket")]
    public string Rocket { get; set; }

    [JsonProperty("success")]
    public bool? Success { get; set; }

    [JsonProperty("failures")]
    public List<object> Failures { get; set; }

    [JsonProperty("details")]
    public string Details { get; set; }

    [JsonProperty("crew")]
    public List<object> Crew { get; set; }

    [JsonProperty("ships")]
    public List<object> Ships { get; set; }

    [JsonProperty("capsules")]
    public List<string> Capsules { get; set; }

    [JsonProperty("payloads")]
    public List<string> Payloads { get; set; }

    [JsonProperty("launchpad")]
    public string Launchpad { get; set; }

    [JsonProperty("auto_update")]
    public bool? AutoUpdate { get; set; }

    [JsonProperty("flight_number")]
    public int? FlightNumber { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("date_utc")]
    public DateTime? DateUtc { get; set; }

    [JsonProperty("date_unix")]
    public int? DateUnix { get; set; }

    private DateTime _dateLocal;

    [JsonProperty("date_local")]
    public DateTime? DateLocal
    {
        get => _dateLocal;
        set => _dateLocal = value ?? DateTime.MinValue;
    }

    [JsonProperty("date_precision")]
    public string DatePrecision { get; set; }

    [JsonProperty("upcoming")]
    public bool? Upcoming { get; set; }

    [JsonProperty("cores")]
    public List<LaunchCore> Cores { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }
}