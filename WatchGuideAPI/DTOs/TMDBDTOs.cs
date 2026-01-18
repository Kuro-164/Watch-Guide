using System.Text.Json.Serialization;

namespace WatchGuideAPI.DTOs
{
    // ================= TMDB RAW RESPONSE =================
    public class TMDBSearchResult
    {
        public int Id { get; set; }

        public string? Title { get; set; }      // movie
        public string? Name { get; set; }       // tv

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

    // ================= API RESPONSE =================
    public class ContentDetailsResponse
    {
        public int TmdbId { get; set; }
        public string? Title { get; set; }
        public string Type { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? PosterUrl { get; set; }
        public string? BackdropUrl { get; set; }

        public float Rating { get; set; }
        public string? Language { get; set; }

        public List<string> Genres { get; set; } = new();
        public List<StreamingPlatformDto> StreamingPlatforms { get; set; } = new();
        public List<CastDto> Cast { get; set; } = new();
    }
}
