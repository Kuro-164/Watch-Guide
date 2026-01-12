using System.Text.Json.Serialization;

namespace WatchGuideAPI.DTOs
{
    public class TmdbCreditsDto
    {
        [JsonPropertyName("cast")]
        public List<TmdbCastPerson> Cast { get; set; }
    }

    public class TmdbCastPerson
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("character")]
        public string Character { get; set; }

        [JsonPropertyName("profile_path")]
        public string ProfilePath { get; set; }
    }
}
