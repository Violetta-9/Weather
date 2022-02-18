using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Polly;
using Weather.Application.Queries;
using Weather.Contracts.Models;
using Weather.Filter;
using Weather.Models;

namespace Weather.Controllers
{
    public class WeatherController : Controller
    {
        public readonly IMediator _mediator;
        public WeatherController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<ActionResult> Index()
        {
            return View("Question");
        }

      [NotFoundCityException]
        public  async Task<ActionResult> Details(string cityName)
        {
            
            var cityLocationInfo = await _mediator.Send((new GetCityLocationQuery(cityName)));
            var weatherNowInfo = await _mediator.Send(new GetNowWeatherQuery(cityName));
        
            var weatherDailyInfo = await _mediator.Send(new GetWeatherDailyQuery(
                cityLocationInfo.Results[0].Locations[1].LatLng.Lat,
                cityLocationInfo.Results[0].Locations[1].LatLng.Lng));
            var infoAboutWeather = new WeatherViewModel()
            {
                NowWeatherInfo = weatherNowInfo,
                WeatherFor5Days = weatherDailyInfo
            };
            return View(infoAboutWeather);
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
        public ActionResult Exception()
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
