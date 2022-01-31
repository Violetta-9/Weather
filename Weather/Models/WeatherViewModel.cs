using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Domain.Models;

namespace Weather.Models
{
    public class WeatherViewModel
    {
        public WeatherInfo NowWeatherInfo { get; set; }
        public WeatherDaily WeatherFor5Days { get; set; }
    }
}
