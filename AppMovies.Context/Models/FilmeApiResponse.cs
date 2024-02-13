using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppMovies.Models
{
    public class FilmeApiResponse
    {
        [JsonProperty("search")]
        public List<FilmeViewModel> Filmes { get; set; }
        [JsonProperty("totalResults")]
        public string TotalResults { get; set; }
        [JsonProperty("Response")]
        public string Response { get; set; }

        
    }
}
