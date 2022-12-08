﻿using Security.Models.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Security.DAO
{
    /// <summary>
    /// DAO class used to interact with the user and role tables
    /// </summary>
    public class UserSecurityDAO : IUserSecurityDAO
    {
        #region Variables

        /// <summary>
        /// SQL query that gets the last autogenerated primary key
        /// </summary>
        private const string _getLastIdSQL = "SELECT CAST(SCOPE_IDENTITY() as int);";

        /// <summary>
        /// Database connection string
        /// </summary>
        private string _connectionString;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString">Database connection string</param>
        public UserSecurityDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        #endregion 

        #region UserItem Methods

        /// <summary>
        /// Adds a user to the database
        /// </summary>
        /// <param name="item">The user item to add</param>
        /// <returns>The autogenerated primary key</returns>
        public int AddUserItem(UserItem item)
        {
            const string sql = "INSERT [User] (firstName, lastName, Email, Hash, Salt, RoleId, Phone) " +
                               "VALUES (@FirstName, @LastName, @Email, @Hash, @Salt, @RoleId, @Phone);";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql + _getLastIdSQL, conn);
                cmd.Parameters.AddWithValue("@FirstName", item.FirstName);
                cmd.Parameters.AddWithValue("@LastName", item.LastName);
                cmd.Parameters.AddWithValue("@Email", item.Email);
                cmd.Parameters.AddWithValue("@Hash", item.Hash);
                cmd.Parameters.AddWithValue("@Salt", item.Salt);
                cmd.Parameters.AddWithValue("@RoleId", item.RoleId);
                cmd.Parameters.AddWithValue("@Phone", item.Phone);
                item.Id = (int)cmd.ExecuteScalar();
            }

            return item.Id;
        }

        /// <summary>
        /// Updates a row in the user table
        /// </summary>
        /// <param name="item">The user item to be changed</param>
        /// <returns>True if the record was successfully updated</returns>
        public bool UpdateUserItem(UserItem item)
        {
            bool isSuccessful = false;

            const string sql = "UPDATE [User] SET FirstName = @FirstName, " +
                                                 "LastName = @LastName, " +
                                                 "Email = @Email, " +
                                                 "Phone = @Phone, " +
                                                 "Hash = @Hash, " +
                                                 "Salt = @Salt " +
                                                 "WHERE Id = @Id;";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@FirstName", item.FirstName);
                cmd.Parameters.AddWithValue("@LastName", item.LastName);
                cmd.Parameters.AddWithValue("@Email", item.Email);
                cmd.Parameters.AddWithValue("@Phone", item.Phone);
                cmd.Parameters.AddWithValue("@Hash", item.Hash);
                cmd.Parameters.AddWithValue("@Salt", item.Salt);
                cmd.Parameters.AddWithValue("@Id", item.Id);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    isSuccessful = true;
                }
            }

            return isSuccessful;
        }

        /// <summary>
        /// Deletes a row from the user table
        /// </summary>
        /// <param name="userId">The primary key for the user item to be deleted</param>
        public void DeleteUserItem(int userId)
        {
            const string sql = "DELETE FROM [User] WHERE userId = @Id;";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", userId);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Gets a row from the user table
        /// </summary>
        /// <param name="userId">The primary key of the user item to retrieve</param>
        /// <returns>A user item holding the data from the user table row</returns>
        public UserItem GetUserItem(int userId)
        {
            UserItem user = null;
            const string sql = "SELECT * From [User] WHERE Id = @userId;";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    user = GetUserItemFromReader(reader);
                }
            }

            if (user == null)
            {
                throw new Exception("User does not exist.");
            }

            return user;
        }

        /// <summary>
        /// Gets a list of rows from the user table
        /// </summary>
        /// <returns>A list of populate user items from the user table</returns>
        public List<UserItem> GetUserItems()
        {
            List<UserItem> users = new List<UserItem>();
            const string sql = "Select * From [User];";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(GetUserItemFromReader(reader));
                }
            }

            return users;
        }

        /// <summary>
        /// Gets a row from the user table
        /// </summary>
        /// <param name="username">The username of the user item to retrieve</param>
        /// <returns>A user item holding the data from the user table row</returns>
        public UserItem GetUserItem(string email)
        {
            UserItem user = null;
            const string sql = "SELECT * From [User] WHERE email = @email;";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@email", email);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    user = GetUserItemFromReader(reader);
                }
            }

            if (user == null)
            {
                throw new Exception("User does not exist.");
            }

            return user;
        }

        /// <summary>
        /// Parses the user data from the sql reader
        /// </summary>
        /// <param name="reader">Result set containing data to be parsed</param>
        /// <returns>A populated user item from the sql data reader</returns>
        private UserItem GetUserItemFromReader(SqlDataReader reader)
        {
            UserItem item = new UserItem();

            item.Id = Convert.ToInt32(reader["Id"]);
            item.FirstName = Convert.ToString(reader["FirstName"]);
            item.LastName = Convert.ToString(reader["LastName"]);
            item.Email = Convert.ToString(reader["Email"]);
            item.Phone = Convert.ToString(reader["Phone"]);
            item.Salt = Convert.ToString(reader["Salt"]);
            item.Hash = Convert.ToString(reader["Hash"]);
            item.RoleId = Convert.ToInt32(reader["RoleId"]);

            return item;
        }

        #endregion

        #region RoleItem

        /// <summary>
        /// Adds a role item to the role table
        /// </summary>
        /// <param name="item">The role item data to be added</param>
        /// <returns>The primary key of the new record</returns>


        /// <summary>
        /// Gets a list of all the role items in the role table
        /// </summary>
        /// <returns>List of role items</returns>
        public List<RoleItem> GetRoleItems()
        {
            List<RoleItem> roles = new List<RoleItem>();
            const string sql = "Select * From role;";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    roles.Add(GetRoleItemFromReader(reader));
                }
            }

            return roles;
        }

        /// <summary>
        /// Parses the role data from the sql reader
        /// </summary>
        /// <param name="reader">Result set containing data to be parsed</param>
        /// <returns>A populated role item from the sql data reader</returns>
        private RoleItem GetRoleItemFromReader(SqlDataReader reader)
        {
            RoleItem item = new RoleItem();

            item.Id = Convert.ToInt32(reader["Id"]);
            item.Name = Convert.ToString(reader["Name"]);

            return item;
        }


        #endregion
    }
}