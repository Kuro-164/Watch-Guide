using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.DTOs
{
    public class ContentCardDto
    {
        public int TmdbId { get; set; }
        public string Title { get; set; }
        public string PosterUrl { get; set; }
        public string MediaType { get; set; }
    }
}
