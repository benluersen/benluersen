using ParkGeek.DAL.Models;
using ParkGeekMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ParkGeek.DAL
{
    public class ParkGeekDAO : IParkGeekDAO
    {
        #region variables
        private string _connectionString;

        public ParkGeekDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        #endregion
        
        #region park methods
        public IList<Park> GetAllParks()
        {
            IList<Park> parks = new List<Park>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM park;", conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    parks.Add(MapRowToPark(reader));
                }
            }

            return parks;
        }

        

        public Park GetPark(string parkCode)
        {
            Park park = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
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
                AnnualVisitors = Convert.ToInt32(reader["annualVisitorCount"]),
                InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]),
                InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]),
                ParkDescription = Convert.ToString(reader["parkDescription"]),
                EntryFee = Convert.ToDecimal(reader["entryFee"]),
                NumAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]),

            };

        }

        #endregion

        #region survey methods
        public bool AddNewSurvey(SurveyResult survey)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel)" +
                    " VALUES (@parkCode, @emailAddress, @state, @activityLevel);", conn);

                cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                cmd.Parameters.AddWithValue("@emailAddress", survey.Email);
                cmd.Parameters.AddWithValue("@state", survey.State);
                cmd.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);

                int rowsAffected = cmd.ExecuteNonQuery();
                if(rowsAffected == 1)
                {
                    result = true;
                }
            }
            return result;
        }

        public IList<Surveys> GetSurveyParkList()
        {
            List<Surveys> parkSurveyList = new List<Surveys>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT survey_result.parkCode, COUNT (*) AS 'ReviewNum' FROM survey_result " +
                    "JOIN park ON survey_result.parkCode = park.parkCode " +
                    "GROUP BY survey_result.parkCode, park.parkName " +
                    "ORDER BY 'ReviewNum' DESC, park.parkName; ", conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    parkSurveyList.Add(MapRowToSurveys(reader));
                }
                
            }
            return parkSurveyList;
        }

        private Surveys MapRowToSurveys(SqlDataReader reader)
        {
            Park park = GetPark(Convert.ToString(reader["parkCode"]));
            int numberReviews = Convert.ToInt32(reader["ReviewNum"]);
            return new Surveys()
            {
                Park = park,
                NumberOfReviews = numberReviews,
            };
        }
        #endregion

        #region weather methods

        public IList<Weather> GetFiveDayWeather(string parkCode)
        {
            IList<Weather> weatherList = new List<Weather>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM weather Where parkCode = @parkCode;", conn);
                cmd.Parameters.AddWithValue("@parkCode", parkCode);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    weatherList.Add(MapRowToWeather(reader));
                }
            }

            return weatherList;
        }

        private Weather MapRowToWeather(SqlDataReader reader)
        {
            return new Weather()
            {
                ParkCode = Convert.ToString(reader["parkCode"]),
                FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]),
                LowTemp = Convert.ToInt32(reader["low"]),
                HighTemp = Convert.ToInt32(reader["high"]),
                Forecast = Convert.ToString(reader["forecast"])
            };
        }

        #endregion
        
    }
}
