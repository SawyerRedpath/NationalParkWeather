using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;
using SessionCart.Web.Extensions;
using Microsoft.AspNetCore.Routing;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        IParkDal _parkDal;
        IForecastDal _forecastDal;

        public HomeController(IParkDal parkDal, IForecastDal forecastDal)
        {
            this._parkDal = parkDal;
            this._forecastDal = forecastDal;
        }

        public IActionResult Index()
        {
            var parks = _parkDal.GetParks();

            return View(parks);
        }

        public IActionResult Detail(string parkCode)
        {
            var park = _parkDal.GetPark(parkCode);

            return View(park);
        }

        [HttpGet]
        public IActionResult Forecast(string parkCode)
        {
            var forecasts = _forecastDal.GetForecasts(parkCode);

            // var degree = get current degree
            var degree = GetCurrentDegree();
            
            
            // if degree c go through list of forecasts and convert it to celsius and set degree property to "C" THEN return view with new forecasts
            if (degree == "C")
            {
                foreach(var forecast in forecasts)
                {
                    forecast.Degree = "C";
                    forecast.High = forecast.FahrenheitToCelsius(forecast.High);
                    forecast.Low = forecast.FahrenheitToCelsius(forecast.Low);
                }
        
            }
  
            return View(forecasts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Forecast(string parkCode, string degree)
        {
            SaveCurrentDegree(degree);

            // Redirect to action Forecast get with parkcode and degree in query string
            return RedirectToAction("Forecast", new { parkCode });
        }

        //2 private methods.

        // 1 to save degree value to session
        private void SaveCurrentDegree(string degree)
        {
            HttpContext.Session.Set<string>("Degree", degree);
        }

        // 2 to get the current degree
        private string GetCurrentDegree()
        {
            string currentDegree = HttpContext.Session.Get<string>("Degree");
            if (currentDegree == null)
            {
                currentDegree = "F";
                HttpContext.Session.Set<string>("Degree", currentDegree);
            }
            return currentDegree;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
