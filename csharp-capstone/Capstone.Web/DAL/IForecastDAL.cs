using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public interface IForecastDAL
    {
        /// <summary>
        /// Gets a list of WeatherForecasts for a given park.
        /// </summary>
        /// <param name="parkCode"></param>
        /// <returns></returns>
        IList<WeatherForecast> GetForecasts(string parkCode);
    }
}
