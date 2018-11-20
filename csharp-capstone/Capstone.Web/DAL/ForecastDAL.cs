using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class ForecastDAL : IForecastDAL
    {
        private string connectionString;

        public ForecastDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Gets a forecast for a given park.
        /// </summary>
        /// <param name="parkCode">The parkcode for the park.</param>
        /// <returns>The forecast for the park.</returns>
        public IList<WeatherForecast> GetForecasts(string parkCode)
        {
            IList<WeatherForecast> forecasts = new List <WeatherForecast>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM weather WHERE parkCode = @parkCode;", conn);
                cmd.Parameters.AddWithValue("@parkCode", parkCode);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    forecasts.Add(MapRowToForecast(reader));
                }
            }
                return forecasts;
        }

        private WeatherForecast MapRowToForecast(SqlDataReader reader)
        {
            return new WeatherForecast()
            {
                ParkCode = Convert.ToString(reader["parkCode"]),
                FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]),
                Low = Convert.ToInt32(reader["low"]),
                High = Convert.ToInt32(reader["high"]),
                Forecast = Convert.ToString(reader["forecast"])
            };
        }
    }
}
