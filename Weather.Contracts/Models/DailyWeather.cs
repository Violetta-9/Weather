using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Weather.Contracts.Models
{
    public class Temp
    {   [JsonProperty("day")]
        public double Day { get; set; }
        [JsonProperty("min")]
        public double MinTemp { get; set; }
        [JsonProperty("max")]
        public double MaxTemp { get; set; }
        [JsonProperty("night")]
        public double Night { get; set; }
        [JsonProperty("eve")]
        public double Evening { get; set; }
        [JsonProperty("morn")]
        public double Morning { get; set; }
    }

    public class FeelsLike
    {
        [JsonProperty("day")]
        public double Day { get; set; }
        [JsonProperty("night")]
        public double Night { get; set; }
        [JsonProperty("eve")]
        public double Evening { get; set; }
        [JsonProperty("morn")]
        public double Morning { get; set; }
    }

    public class WeatherFor5Day
    {
       [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("icon")]
        public string Icon { get; set; }
    }

    public class Daily
    {
        [JsonConverter(typeof(CustomDateTimeConverter))]
        [JsonProperty("dt")]
        public DateTime Dt { get; set; }
        [JsonProperty("sunrise")]
        public int Sunrise { get; set; }
        [JsonProperty("sunset")]
        public int Sunset { get; set; }
        [JsonProperty("temp")]
        public Temp Temp { get; set; }
        [JsonProperty("feels_like")]
        public FeelsLike FeelsLike { get; set; }
        [JsonProperty("pressure")]
        public int Pressure { get; set; }
        [JsonProperty("humidity")]
        public int Humidity { get; set; }
        [JsonProperty("wind_speed")]
        public double WindSpeed { get; set; }
        public List<WeatherFor5Day> Weather { get; set; }
        [JsonProperty("clouds")]
        public int Clouds { get; set; }
        public double Pop { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double Snow { get; set; }//объем осадков при наличии
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double Rain { get; set; }
        
    }
    public class WeatherDaily
    {
        public List<Daily> Daily { get; set; }
    }

}
