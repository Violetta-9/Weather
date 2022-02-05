using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Weather.Contracts.Models;

namespace Weather.Application.Queries
{
    public class GetCityLocationQuery:IRequest<CityInfo>
    {
        public string CityName { get; set; }

        public GetCityLocationQuery(string cityName)
        {
            CityName = cityName;
        }
    }
}
