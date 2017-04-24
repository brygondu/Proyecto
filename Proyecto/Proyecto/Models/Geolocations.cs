using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public class Geolocations
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("FechaCreacion")]
        public DateTime FechaCreacion { get; set; }

        [JsonProperty("Latitud")]
        public string Latitud { get; set; }

        [JsonProperty("Longitud")]
        public string Longitud { get; set; }


        //public string Coordinates { get; set; }

    }
}
