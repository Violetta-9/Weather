using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Weather.Contracts.Models;

namespace Weather.Contracts.Models
{
    [System.Serializable]
    public class WeatherInfo
    {
      
        [JsonProperty("weather")]
        public List<Weather> WeatherList { get; set; }
    
        [JsonProperty("main")] 
        public Main Main { get; set; }

        [JsonProperty("visibility")] 
        public int Visibility { get; set; }
        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("clouds")]
        public Clouds CloudsNumber { get; set; }

        [JsonProperty("dt")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime Dt { get; set; }
        [JsonProperty("sys")]
        public Sys Sys { get; set; }
        [JsonProperty("dt_txt")]
        public string Time { get; set; }

       
    }

    [System.Serializable]
    public class Coord
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
    }

    [System.Serializable]
    public class Weather
    {
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("icon")]
        
        public string Icon { get; set; }

    }

   

    [System.Serializable]
    public class Main
    {
        [JsonProperty("temp")]
        public float Temperature { get; set; }
        [JsonProperty("feels_like")]
        public float FeelsTemperature { get; set; }
        [JsonProperty("pressure")]
        public int Pressure { get; set; }// атмосферное давление
        [JsonProperty("humidity")]
        public int Humidity { get; set; }//влажность

      
    }

    [System.Serializable]
    public class Wind
    {
        [JsonProperty("speed")] 
        public double WindSpeed { get; set; }
        [JsonProperty("gust")]
        public double Gust { get; set; }
    }

    [System.Serializable]
    public class Clouds
    {
        [JsonProperty("all")]
        public int CloudsNumber { get; set; }

    }

    [System.Serializable]
    public class Sys
    {
        [JsonProperty("sunrise")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime Sunrise { get; set; }
        [JsonProperty("sunset")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime Sunset { get; set; }
        [JsonProperty("pod")]
        public string DayOrNight { get; set; }
    }
  
   
}
public class CustomDateTimeConverter : DateTimeConverterBase
{
    private static readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        writer.WriteRawValue(((DateTime)value - _epoch).TotalMilliseconds + "000");
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader.Value == null) { return null; }
        return _epoch.AddSeconds((long)reader.Value).ToLocalTime();
    }
}
