using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Weather.Application.Queries;
using Weather.Contracts.Models;

namespace Weather.Application.QueryHandlers
{
    public class GetNowWeatherQueryHandler : IRequestHandler<GetNowWeatherQuery, WeatherInfo>
    {
        public readonly string _token;

        public GetNowWeatherQueryHandler(IOptions<WeatherCredentials> token)
        {
            _token = token.Value.Token;
        }
        public async Task<WeatherInfo> Handle(GetNowWeatherQuery request, CancellationToken cancellationToken)
        {
            var client = new HttpClient();
            var requestForWeatherNow = new HttpRequestMessage()
            {
                RequestUri =
                    new Uri(
                        $"https://api.openweathermap.org/data/2.5/weather?q=Vitebsk&units=metric&appid={_token}&lang=ru"),//todo: название города
                Method = HttpMethod.Get

            };
            using (var response = await client.SendAsync(requestForWeatherNow))
            {
                response.EnsureSuccessStatusCode();
                var weatherInfo =  await response.Content.ReadAsStringAsync();
                var weatherInfoToClass = JsonConvert.DeserializeObject<WeatherInfo>(weatherInfo);
                return weatherInfoToClass;

            }
        }
    }
}
