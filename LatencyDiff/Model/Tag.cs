using Newtonsoft.Json;

namespace LatencyDiff.Model
{
    public class Tag
    {
        [JsonProperty("id")]
        public string Name { get; set; }
        [JsonProperty("icon_url")]
        public string IconUrl { get; set; }
        [JsonProperty("followers_count")]
        public int FollowersCount { get; set; }
        [JsonProperty("items_count")]
        public int ItemsCount { get; set; }
    }
}
