
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppMovies.Models
{
    public class FilmeViewModel
    {
        public int Id { get; set; }
        [JsonProperty("Title")]
        public string Titulo { get; set; }

        [JsonProperty("Year")]
        public string Ano { get; set; }

        [JsonProperty("imdbID")]
        public string ImdbID { get; set; }

        [JsonProperty("Type")]
        public string Tipo { get; set; }

        [JsonProperty("Poster")]
        public string Poster { get; set; }

        [JsonProperty("Plot")]
        public string Sinopse { get; set; }

        [JsonProperty("Director")]
        public string Director { get; set; }

        [JsonProperty("Actors")]
        public string Actors { get; set; }

        [JsonProperty("Genre")]
        public string Genre { get; set; }


    }


}

