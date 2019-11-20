using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Capstone.DAL
{
    public class NpServicesDAO
    {
        #region Variables

        private const string _getLastIdSQL = "Select Cast(SCOPE_IDENTITY() as int);";
        private string _connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=npcampground;Integrated Security=True";

        #endregion

        #region Constructors

        public NpServicesDAO()
        {
          
        }
        #endregion

        #region GettingMethods

        /// <summary>
        /// Retrieves a list of parks and all their attributes
        /// </summary>
        /// <returns></returns>

        public  List<Park> GetParks()
        {
            List<Park> listOfParks = new List<Park>();
            const string getParksSQL = "SELECT * FROM park ORDER BY name;";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(getParksSQL, conn);
                var reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    listOfParks.Add(GetParksFromReader(reader));
                }
            }
            return listOfParks;
        }

        /// <summary>
        /// Makes a Park from the data being retrieved by the SQL reader.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>

        private Park GetParksFromReader(SqlDataReader reader)
        {
            Park newPark = new Park();

            newPark.park_id = Convert.ToInt32(reader["park_id"]);
            newPark.name = reader["name"].ToString();
            newPark.location = reader["location"].ToString();
            newPark.visitors = Convert.ToInt32(reader["visitors"]);
            newPark.establishDate = Convert.ToDateTime(reader["establish_date"]);
            newPark.area = Convert.ToInt32(reader["area"]);
            newPark.description = reader["description"].ToString();

            return newPark;
        }

        /// <summary>
        /// Makes a list of sites and their attributes
        /// </summary>
        /// <returns></returns>
        public List<Site> getAvailableSites(string startDate, string endDate, int campgroundId)
        {
            List<Site> listOfSites = new List<Site>();
            const string getAvailableSitesSQL = "SELECT TOP 5 site.site_id, site.accessible, site.site_number, site.max_occupancy,site.max_rv_length, site.utilities, site.campground_id " +
                "FROM site " +
                "JOIN reservation ON site.site_id = reservation.site_id " +
                "JOIN campground ON site.campground_id = campground.campground_id " +
                "WHERE(NOT(reservation.from_date > CAST(@endDate AS DATE)) OR(reservation.to_date < CAST(@startDate AS DATE)))  " +
                "AND campground.campground_id = @campgroundId " +
                "GROUP BY site.site_id, site.accessible, site.site_number, site.max_occupancy,site.max_rv_length, site.utilities, site.campground_id;";


            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(getAvailableSitesSQL, conn);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);
                cmd.Parameters.AddWithValue("@campgroundId", campgroundId);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listOfSites.Add(GetSitesFromReader(reader));
                }
            }
            return listOfSites;
        }

        /// <summary>
        /// gets site data from the SQL reader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private Site GetSitesFromReader(SqlDataReader reader)
        {
            Site newSite = new Site();

            newSite.site_id = Convert.ToInt32(reader["site_id"]);
            newSite.site_id = Convert.ToInt32(reader["site_number"]);
            newSite.max_occupancy = Convert.ToInt32(reader["max_occupancy"]);
            newSite.max_rv_length = Convert.ToInt32(reader["max_rv_length"]);
            newSite.utilities = Convert.ToBoolean(reader["utilities"]);

            return newSite;
        }

        /// <summary>
        /// returns a list of reservations from the database
        /// </summary>
        /// <returns></returns>
        public List<reservation> getReservations()
        {
            List<reservation> listOfReservations = new List<reservation>();
            const string getReservationsSQL = "SELECT * FROM reservation;";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(getReservationsSQL, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listOfReservations.Add(GetReservationsFromReader(reader));
                }
            }
            return listOfReservations;
        }

        /// <summary>
        /// gets reservation data from sql reader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private reservation GetReservationsFromReader(SqlDataReader reader)
        {
            reservation newReservation = new reservation();

            newReservation.reservation_id = Convert.ToInt32(reader["reservation_id"]);
            newReservation.name = (reader["name"]).ToString();
            newReservation.site_id = Convert.ToInt32(reader["site_id"]);
            newReservation.from_date = Convert.ToDateTime(reader["from_date"]);
            newReservation.to_date = Convert.ToDateTime(reader["to_date"]);

            return newReservation;
        }

        #endregion

        #region select campgrounds
        /// <summary>
        /// makes list of all campgrounds in a park
        /// </summary>
        /// <returns></returns>
        public List<Campground> getCampgrounds(string parkId)
        {
            List<Campground> listOfCampgrounds = new List<Campground>();
            const string getCampgroundsSQL = "SELECT * FROM campground WHERE park_id = @parkId;";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(getCampgroundsSQL, conn);
                cmd.Parameters.AddWithValue("@parkId", parkId);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listOfCampgrounds.Add(GetCamprgroundsFromReader(reader));
                }
            }
            return listOfCampgrounds;
        }

        /// <summary>
        /// gets campground data from SQL reader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private Campground GetCamprgroundsFromReader(SqlDataReader reader)
        {
            Campground newCampground = new Campground();

            newCampground.campground_id = Convert.ToInt32(reader["campground_id"]);
            newCampground.name = (reader["name"]).ToString();
            newCampground.park_id = Convert.ToInt32(reader["park_id"]);
            newCampground.daily_fee = Convert.ToDecimal(reader["daily_fee"]);
            newCampground.open_from_mm = Convert.ToInt32(reader["open_from_mm"]);
            newCampground.open_to_mm = Convert.ToInt32(reader["open_to_mm"]);

            return newCampground;
            

        }
        #endregion

        #region select park

        /// <summary>
        /// get's all the information from the park to display to the user in the menu
        /// </summary>
        /// <param name="parkId"></param>
        /// <returns></returns>
        public List<Park> GetInfoParks(string parkId)
        {
            List<Park> listOfParks = new List<Park>();
            const string getParksSQL = "SELECT * FROM park WHERE park_id = @parkId;";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(getParksSQL, conn);
                cmd.Parameters.AddWithValue("@parkId", parkId);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listOfParks.Add(GetParksFromReader(reader));
                }
            }
            return listOfParks;
        }

        #endregion

        #region Make a Reservation

        /// <summary>
        /// makes a reservation and adds it to the database as well as checking to see if the entered dates are valid.
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="name"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public string MakeReservation(string siteId, string name, string fromDate, string toDate)
        {

            const string getReservationSQL = "INSERT reservation (site_id, name, from_date, to_date, create_date) " +
                                        "VALUES (@site_id, @name, @from_date, @to_date, @create_date );";
            string reservationId = "";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(getReservationSQL, conn);
                DateTime createDate = DateTime.UtcNow;
                cmd.Parameters.AddWithValue("@site_id", siteId);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@from_date", fromDate);
                cmd.Parameters.AddWithValue("@to_date", toDate);
                cmd.Parameters.AddWithValue("@create_date", createDate);
                var reader = cmd.ExecuteReader();

                reservationId = GetReservationID(createDate);
            }
            return reservationId;
        }
        private string GetReservationID(DateTime createDate)
        {
            reservation newReservation = new reservation();
            const string getReservationIdSQL = "SELECT reservation_id FROM reservation WHERE create_date = @createDate;";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(getReservationIdSQL, conn);
                cmd.Parameters.AddWithValue("@createDate", createDate);
                    var reader = cmd.ExecuteReader();
                reader.Read();
                newReservation.reservation_id = Convert.ToInt32(reader["reservation_id"]);
            }
            string reservationId = newReservation.reservation_id.ToString();
            return reservationId;
        }
        #endregion
        
    }
}
