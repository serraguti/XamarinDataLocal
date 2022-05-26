using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinDataLocal.Models
{
    public class Serie
    {
        [JsonProperty("idserie")]
        public int IdSerie { get; set; }
        [JsonProperty("nombre")]
        public string Nombre { get; set; }
        [JsonProperty("imagen")]
        public string Imagen { get; set; }
        [JsonProperty("valoracion")]
        public int Valoracion { get; set; }
    }
}
