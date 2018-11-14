using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class ParkDAL : IParkDAL
    {
        private string connectionString;

        public ParkDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Gets a single park.
        /// </summary>
        /// <param name="parkCode"></param>
        /// <returns></returns>
        public Park GetPark(string parkCode)
        {
            Park park = new Park();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM park WHERE parkCode = @parkCode;", conn);
                cmd.Parameters.AddWithValue("@parkCode", parkCode);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    park = MapRowToPark(reader);
                }
            }

            return park;
        }

        /// <summary>
        /// Gets all parks.
        /// </summary>
        /// <returns></returns>
        public IList<Park> GetParks()
        {
            IList<Park> parks = new List<Park>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM park;", conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    parks.Add(MapRowToPark(reader));
                }
            }

                return parks;
        }

        /// <summary>
        /// Maps a row to a park
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private Park MapRowToPark(SqlDataReader reader)
        {
            return new Park()
            {
                ParkCode = Convert.ToString(reader["parkCode"]),
                ParkName = Convert.ToString(reader["parkName"]),
                State = Convert.ToString(reader["state"]),
                Acreage = Convert.ToInt32(reader["acreage"]),
                ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]),
                MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]),
                NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]),
                Climate = Convert.ToString(reader["climate"]),
                YearFounded = Convert.ToInt32(reader["yearFounded"]),
                AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]),
                InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]),
                InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]),
                ParkDescription = Convert.ToString(reader["parkDescription"]),
                EntryFee = Convert.ToDecimal(reader["entryFee"]),
                NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"])
            };
        }
    }
}
