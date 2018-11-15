using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class SurveyDAL : ISurveyDAL
    {
        private string connectionString;
        public SurveyDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddSurvey(Survey survey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT into survey_result VALUES (@parkCode, @emailAddress, @state, @activityLevel);", conn);
                    cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", survey.EmailAddress);
                    cmd.Parameters.AddWithValue("@state", survey.State);
                    cmd.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);
                    cmd.ExecuteNonQuery();
                }
            }
            catch(SqlException ex)
            {
                throw;
            }
        }

        public Dictionary<string, int> GetSurveyResults()
        {
            Dictionary<string, int> surveyResults = new Dictionary<string, int>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT parkCode, count(*) as hits 
                FROM survey_result 
                GROUP BY parkCode
                ORDER BY hits desc, parkCode;", conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    surveyResults.Add(Convert.ToString(reader["parkCode"]), Convert.ToInt32(reader["hits"]));
                }

                return surveyResults;
            }
        }
    }
}
