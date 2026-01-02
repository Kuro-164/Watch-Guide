using System.Text.Json.Serialization;

namespace WatchGuideAPI.DTOs
{
    public class TMDBSearchResult
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Name { get; set; } // For TV shows

        public string Overview { get; set; }

        [JsonPropertyName("poster_path")]
        public string PosterPath { get; set; }

        [JsonPropertyName("media_type")]
        public string MediaType { get; set; } // "movie" or "tv"

        [JsonPropertyName("vote_average")]
        public double VoteAverage { get; set; }

        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; }

        [JsonPropertyName("first_air_date")]
        public string FirstAirDate { get; set; }
    }

    public class SearchResponse
    {
        public List<TMDBSearchResult> Results { get; set; }
    }

    public class ContentDetailsResponse
    {
        public int TmdbId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string PosterUrl { get; set; }
        public string BackdropUrl { get; set; }
        public float Rating { get; set; }
        public List<string> Genres { get; set; }
        public List<string> StreamingPlatforms { get; set; }
    }
}