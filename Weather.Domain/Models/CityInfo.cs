using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Weather.Domain.Models
{

    public class ProvidedLocation
    {[JsonProperty("location")]
        public string Location { get; set; }
    }

    public class LatLng
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
    }



    public class Location
    {
        [JsonProperty("adminArea6Type")]
        public string CityName { get; set; }

        public LatLng LatLng { get; set; }

        public string MapUrl { get; set; }
    }

    public class Result
    {
        public ProvidedLocation ProvidedLocation { get; set; }
        public List<Location> Locations { get; set; }
    }

    public class CitiInfo
    {

        public List<Result> Results { get; set; }
    }

}
