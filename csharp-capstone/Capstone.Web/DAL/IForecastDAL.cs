using Capstone.Web.Models;
using System.Collections.Generic;

namespace Capstone.Web.DAL
{
    public interface IForecastDal
    {
        /// <summary>
        /// Gets a list of WeatherForecasts for a given park.
        /// </summary>
        /// <param name="parkCode"></param>
        /// <returns></returns>
        IList<WeatherForecast> GetForecasts(string parkCode);
    }
}