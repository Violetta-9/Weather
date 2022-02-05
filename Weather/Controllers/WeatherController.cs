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
using Weather.Application.Queries;
using Weather.Contracts.Models;
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
            var weatherNowInfo = await _mediator.Send(new GetNowWeatherQuery("Витебск"));
            var cityLocationInfo = await _mediator.Send((new GetCityLocationQuery("Витебск")));
            var weatherDailyInfo = await _mediator.Send(new GetWeatherDailyQuery(
                cityLocationInfo.Results[0].Locations[0].LatLng.Lat,
                cityLocationInfo.Results[0].Locations[0].LatLng.Lng));
            var infoAboutWeather = new WeatherViewModel()
            {
                NowWeatherInfo = weatherNowInfo,
                WeatherFor5Days = weatherDailyInfo
            };
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
