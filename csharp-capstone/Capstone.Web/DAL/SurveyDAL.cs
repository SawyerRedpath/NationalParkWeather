using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class SurveyDal : ISurveyDal
    {
        private readonly string _connectionString;

        public SurveyDal(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public void AddSurvey(Survey survey)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd =
                    new SqlCommand(
                        "INSERT into survey_result VALUES (@parkCode, @emailAddress, @state, @activityLevel);",
                        conn);
                cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                cmd.Parameters.AddWithValue("@emailAddress", survey.EmailAddress);
                cmd.Parameters.AddWithValue("@state", survey.State);
                cmd.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);
                cmd.ExecuteNonQuery();
            }
        }

        public Dictionary<string, int> GetSurveyResults()
        {
            var surveyResults = new Dictionary<string, int>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(@"SELECT parkCode, count(*) as hits
                FROM survey_result
                GROUP BY parkCode
                ORDER BY hits desc, parkCode;", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    surveyResults.Add(Convert.ToString(reader["parkCode"]), Convert.ToInt32(reader["hits"]));

                return surveyResults;
            }
        }
    }
}