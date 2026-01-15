using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.DTOs
{
    public class ShowDetailDto
    {
        public int TmdbId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Language { get; set; }

        public string Description { get; set; }

        public string PosterUrl { get; set; }
        public string BackdropUrl { get; set; }

        public float Rating { get; set; }

        public List<string> Genres { get; set; }
        public List<StreamingPlatformDto> StreamingPlatforms { get; set; }
        public List<CastDto> Cast { get; set; }
    }
}
