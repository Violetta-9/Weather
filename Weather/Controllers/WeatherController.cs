using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Weather.Domain.Models;
using Weather.Models;

namespace Weather.Controllers
{
    public class WeatherController : Controller
    {
        // GET: WeatherController
        private readonly string _token;

        public WeatherController(IOptions<WeatherCredentials> token)
        {
            _token = token.Value.Token;
        }
        public async Task<ActionResult> Index()
        {
            var client = new HttpClient();
            var infoAboutWeather = new WeatherViewModel();
            var request = new HttpRequestMessage
            {
                

                RequestUri = new Uri($"https://api.openweathermap.org/data/2.5/weather?q=Vitebsk&units=metric&appid={_token}&lang=ru"),


            };
            var request1 = new HttpRequestMessage
            {
                RequestUri =
                    new Uri(
                        $"https://api.openweathermap.org/data/2.5/onecall?lat=55.11&lon=30.12&units=metric&exclude=current,minutely,hourly,alerts&appid={_token}&lang=ru"),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var result = JObject.Parse(body);
                var item  = result.ToObject<WeatherInfo>();
                infoAboutWeather.NowWeatherInfo = item;
            }
            using (var response = await client.SendAsync(request1))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var result = JObject.Parse(body);
                var item = result.ToObject<WeatherDaily>();
                infoAboutWeather.WeatherFor5Days = item;
            }

            return View(infoAboutWeather);
        }

        // GET: WeatherController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WeatherController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WeatherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WeatherController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WeatherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WeatherController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WeatherController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
