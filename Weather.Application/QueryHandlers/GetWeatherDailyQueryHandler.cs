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
    public class GetWeatherDailyQueryHandler : IRequestHandler<GetWeatherDailyQuery, WeatherDaily>
    {
        public readonly string _token;

        public GetWeatherDailyQueryHandler(IOptions<WeatherCredentials> token)
        {
            _token = token.Value.Token;
        }
        public async Task<WeatherDaily> Handle(GetWeatherDailyQuery request, CancellationToken cancellationToken)
        {
            var client = new HttpClient();
            var requestForWeatherDaily = new HttpRequestMessage()
            {
                RequestUri =
                    new Uri(
                        $"https://api.openweathermap.org/data/2.5/onecall?lat=55.11&lon=30.12&units=metric&exclude=current,minutely,hourly,alerts&appid={_token}&lang=ru"),
                Method = HttpMethod.Get
            };
            using (var response = await client.SendAsync(requestForWeatherDaily))
            {
                response.EnsureSuccessStatusCode();
                var weatherInfoDaily = await response.Content.ReadAsStringAsync();
                var weatherInfodailyToClass = JsonConvert.DeserializeObject<WeatherDaily>(weatherInfoDaily);
                return weatherInfodailyToClass;
            }
        }
    }
}
