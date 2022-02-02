using Weather.Contracts.Models;
using Weather.Domain.Models;

namespace Weather.Models
{
    public class WeatherViewModel
    {
        public WeatherInfo NowWeatherInfo { get; set; }
        public WeatherDaily WeatherFor5Days { get; set; }
    }
}
