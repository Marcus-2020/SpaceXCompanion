using Newtonsoft.Json;
using SpaceXCompanion.API.Models.Launches;

namespace SpaceXCompanion.API.Models.Results;

public class LaunchesResult
{
    [JsonProperty("result")]
    public List<Launch> Result { get; set; }

    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("exception")]
    public object Exception { get; set; }

    [JsonProperty("status")]
    public int Status { get; set; }

    [JsonProperty("isCanceled")]
    public bool IsCanceled { get; set; }

    [JsonProperty("isCompleted")]
    public bool IsCompleted { get; set; }

    [JsonProperty("isCompletedSuccessfully")]
    public bool IsCompletedSuccessfully { get; set; }

    [JsonProperty("creationOptions")]
    public int CreationOptions { get; set; }

    [JsonProperty("asyncState")]
    public object AsyncState { get; set; }

    [JsonProperty("isFaulted")]
    public bool IsFaulted { get; set; }
}