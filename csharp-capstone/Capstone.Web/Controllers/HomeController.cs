using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        IParkDAL parkDAL;
        IForecastDAL forecastDAL;

        public HomeController(IParkDAL parkDAL, IForecastDAL forecastDAL)
        {
            this.parkDAL = parkDAL;
            this.forecastDAL = forecastDAL;
        }

        public IActionResult Index()
        {
            var parks = parkDAL.GetParks();

            return View(parks);
        }

        public IActionResult Detail(string parkCode)
        {
            var park = parkDAL.GetPark(parkCode);

            return View(park);
        }

        public IActionResult Forecast(string parkCode)
        {
            var forecasts = forecastDAL.GetForecasts(parkCode);

            return View(forecasts);
        }
      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
