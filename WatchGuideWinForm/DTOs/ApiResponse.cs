using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace WinFormsApp1.DTOs
{
    public class ApiResponse<T>
    {
        [JsonPropertyName("data")]
        public T Data { get; set; }
    }
}


