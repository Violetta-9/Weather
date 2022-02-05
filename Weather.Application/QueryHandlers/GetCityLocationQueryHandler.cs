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
                        $"http://open.mapquestapi.com/geocoding/v1/address?key={_token}&location=витебск"),//todo: название города
                Method = HttpMethod.Get
            };
            using (var response = await client.SendAsync(requestForCityCoordinates))
            {
                response.EnsureSuccessStatusCode();
                var cityInfo = await response.Content.ReadAsStringAsync();
                var cityInfoToClass = JsonConvert.DeserializeObject<CityInfo>(cityInfo);
                return cityInfoToClass;
            }
        }
    }
}
