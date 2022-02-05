using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Weather.Contracts.Models;

namespace Weather.Application.Queries
{
    public class GetWeatherDailyQuery:IRequest<WeatherDaily>
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public GetWeatherDailyQuery(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
