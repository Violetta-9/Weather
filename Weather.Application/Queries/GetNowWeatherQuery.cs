using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Weather.Contracts.Models;


namespace Weather.Application.Queries
{
    public class GetNowWeatherQuery:IRequest<WeatherInfo>
    {
        public string CityName { get; set; }

        public GetNowWeatherQuery(string cityName)
        {
            CityName = cityName;
        }
    }
}
