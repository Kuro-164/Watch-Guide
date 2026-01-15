using System.Collections.Generic;

namespace WinFormsApp1.DTOs
{
    public class TmdbDetailResponse
    {
        // Movie title
        public string Title { get; set; }

        // TV show name
        public string Name { get; set; }

        public string Overview { get; set; }

        public string Poster_Path { get; set; }

        public List<TmdbGenre> Genres { get; set; }
    }

    public class TmdbGenre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
