using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    /// <summary>
    /// Represents a weather forecast.
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// The park code we are getting the forecast for.
        /// </summary>
        public string ParkCode { get; set; }

        /// <summary>
        /// The number of the day.
        /// </summary>
        public int FiveDayForecastValue { get; set; }

        /// <summary>
        /// The low temperature of the day in Fahrenheit.
        /// </summary>
        public int Low { get; set; }

        /// <summary>
        /// The high temperature of the day in Fahrenheit.
        /// </summary>
        public int High { get; set; }

        /// <summary>
        /// The forecasted weather of the day.
        /// </summary>
        public string Forecast { get; set; }
    }
}
