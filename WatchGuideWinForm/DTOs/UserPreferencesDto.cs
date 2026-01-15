using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.DTOs
{
    public class UserPreferencesResponse
    {
        public Guid UserId { get; set; }
        public List<string> Languages { get; set; }
        public List<string> Genres { get; set; }
    }
}
