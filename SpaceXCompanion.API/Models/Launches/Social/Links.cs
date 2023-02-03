using Newtonsoft.Json;

namespace SpaceXCompanion.API.Models.Launches.Social;

public class Links
{
    [JsonProperty("patch")]
    public Patch Patch { get; set; }

    [JsonProperty("reddit")]
    public Reddit Reddit { get; set; }

    [JsonProperty("flickr")]
    public Flickr Flickr { get; set; }

    [JsonProperty("presskit")]
    public string Presskit { get; set; }

    [JsonProperty("webcast")]
    public string Webcast { get; set; }

    [JsonProperty("youtube_id")]
    public string YoutubeId { get; set; }

    [JsonProperty("article")]
    public string Article { get; set; }

    [JsonProperty("wikipedia")]
    public string Wikipedia { get; set; }
}