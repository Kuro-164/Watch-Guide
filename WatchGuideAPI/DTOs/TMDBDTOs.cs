using System.Text.Json.Serialization;

namespace WatchGuideAPI.DTOs
{
    public class TMDBSearchResult
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Name { get; set; }
        public string? MediaType { get; set; }
        public string? PosterPath { get; set; }
        public string? BackdropPath { get; set; }
        public double? VoteAverage { get; set; }
        public string? Overview { get; set; }
        public string? ReleaseDate { get; set; }
        public string? FirstAirDate { get; set; }
        public List<int>? GenreIds { get; set; }

        [JsonPropertyName("original_language")]
        public string? OriginalLanguage { get; set; }
    }

    public class SearchResponse
    {
        public List<TMDBSearchResult>? Results { get; set; }
    }

    public class ContentDetailsResponse
    {
        public int TmdbId { get; set; }
        public string? Title { get; set; }
        public string Type { get; set; }
        public string? Description { get; set; }
        public string? PosterUrl { get; set; }
        public string? BackdropUrl { get; set; }
        public float Rating { get; set; }
        public List<string> Genres { get; set; } = new();
        public List<StreamingPlatformDto> StreamingPlatforms { get; set; } = new();
        public List<CastDto> Cast { get; set; } = new();
    }
}