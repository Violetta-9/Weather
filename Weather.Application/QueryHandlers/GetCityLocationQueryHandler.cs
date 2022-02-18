using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;
using MediatR;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Weather.Application.Queries;
using Weather.Contracts.Exseption;
using Weather.Contracts.Models;

namespace Weather.Application.QueryHandlers
{
    public class GetCityLocationQueryHandler : IRequestHandler<GetCityLocationQuery, CityInfo>
    {
        public readonly string _token;

        public GetCityLocationQueryHandler(IOptions<CityCredentials> token)
        {
            _token = token.Value.Token;
        }
        public async Task<CityInfo> Handle(GetCityLocationQuery request, CancellationToken cancellationToken)
        {
            var client = new HttpClient();
            var requestForCityCoordinates = new HttpRequestMessage
            {
                RequestUri =
                    new Uri(
                        $"http://open.mapquestapi.com/geocoding/v1/address?key={_token}&location={request.CityName}"),
            };
            using (var response = await client.SendAsync(requestForCityCoordinates))
            {
                response.EnsureSuccessStatusCode();
                var cityInfo = await response.Content.ReadAsStringAsync();
                var cityInfoToClass = JsonConvert.DeserializeObject<CityInfo>(cityInfo);
                if (cityInfoToClass.Results[0].Locations[0].LatLng.Lat == 39.78373 &&
                    cityInfoToClass.Results[0].Locations[0].LatLng.Lng == -100.445882)
                {
                    throw new NotFoundCityExseption(cityInfoToClass.Results[0].Locations[0].CityName);
                }
                return cityInfoToClass;
            }
        }
    }
}
