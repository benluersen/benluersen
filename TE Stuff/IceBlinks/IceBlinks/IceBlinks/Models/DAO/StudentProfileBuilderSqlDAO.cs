using Security.Models.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace IceBlinks.Models.DAO
{
    public class StudentProfileBuilderSqlDAO : IStudentProfileBuilderDAO
    {
        #region variables

        private string _connectionString;
        public const string SCOPE_IDENTITY_SQL = "SELECT CAST(SCOPE_IDENTITY() AS INT);";

        public StudentProfileBuilderSqlDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        #endregion variables

        #region Create methods

        public int AddCareer(CareerExperience exp)
        {
            int id = 0;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO CareerExperience (ProfileId, Title, Employer, Industry, StartDate, EndDate, JobDescription)" +
                    "VALUES (@ProfileId, @Title, @Employer, @Industry, @StartDate, @EndDate, @JobDescription);" + SCOPE_IDENTITY_SQL, conn);
                cmd.Parameters.AddWithValue("@ProfileId", exp.ProfileId);
                cmd.Parameters.AddWithValue("@Title", exp.Title);
                cmd.Parameters.AddWithValue("@Employer", exp.Employer);
                cmd.Parameters.AddWithValue("@Industry", exp.Industry);
                cmd.Parameters.AddWithValue("@StartDate", exp.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", exp.EndDate);
                cmd.Parameters.AddWithValue("@JobDescription", exp.JobDescription);
                id = (int)cmd.ExecuteScalar();
            }
            return id;
        }

        public int AddPortfolio(Portfolio portfolio)
        {
            int id = 0;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Portfolio (ProfileId, ProjectTitle, ProjectDescription, ProjectLink)" +
                                                "VALUES (@ProfileId, @ProjectTitle, @ProjectDescription, @ProjectLink);" + SCOPE_IDENTITY_SQL, conn);
                cmd.Parameters.AddWithValue("@ProfileId", portfolio.ProfileId);
                cmd.Parameters.AddWithValue("@ProjectTitle", portfolio.ProjectTitle);
                cmd.Parameters.AddWithValue("@ProjectDescription", portfolio.ProjectDescription);
                cmd.Parameters.AddWithValue("@ProjectLink", portfolio.ProjectLink);
                id = (int)cmd.ExecuteScalar();
            }
            return id;
        }

        public int AddTech(Tech tech)
        {
            int id = 0;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Tech (Name)" +
                                                "VALUES (@Name);" + SCOPE_IDENTITY_SQL, conn);
                cmd.Parameters.AddWithValue("@Name", tech.TechName);
                id = (int)cmd.ExecuteScalar();
            }
            return id;
        }

        public int AddAcademics(Academics academics)
        {
            int id = 0;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Academics (ProfileId, Degree, Institution, StartDate, EndDate, Graduated, Major)" +
                                                "VALUES (@ProfileId, @Degree, @Institution, @StartDate, @EndDate, @Graduated, @Major);" + SCOPE_IDENTITY_SQL, conn);
                cmd.Parameters.AddWithValue("@ProfileId", academics.ProfileId);
                cmd.Parameters.AddWithValue("@Degree", academics.Degree);
                cmd.Parameters.AddWithValue("@Institution", academics.Institution);
                cmd.Parameters.AddWithValue("@StartDate", academics.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", academics.EndDate);
                cmd.Parameters.AddWithValue("@Graduated", academics.Graduated);
                cmd.Parameters.AddWithValue("@Major", academics.Major);
                id = (int)cmd.ExecuteScalar();
            }
            return id;
        }

        public int AddTechPortfolioLink(int techId, int portfolioId)
        {
            int id = 0;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO PortfolioTech (PortfolioId, TechId)" +
                    "VALUES (@PortfolioId, @TechId);" + SCOPE_IDENTITY_SQL, conn);
                cmd.Parameters.AddWithValue("@PortfolioId", portfolioId);
                cmd.Parameters.AddWithValue("@TechId", techId);
                id = (int)cmd.ExecuteScalar();
            }
            return id;
        }

        /// <summary>
        /// Creates a new empty profile connected to the given userId
        /// </summary>
        /// <param name="userId"></param>
        public int CreateProfile(int userId, int cohort = -1)
        {
            int id = 0;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Profile (userId, ContactPreference, searchable, cohort)" +
                    "VALUES (@userId, 'Email', 0, @cohort);" + SCOPE_IDENTITY_SQL, conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@cohort", cohort);
                id = (int)cmd.ExecuteScalar();
            }
            return id;
        }

        #endregion Create methods

        #region Read methods

        public ProfileViewModel GetProfile(int id, bool usingUserId = false)
        {
            ProfileViewModel profile = new ProfileViewModel();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string idType = null;
                if (usingUserId)
                {
                    idType = "[User].id";
                }
                else
                {
                    idType = "[Profile].id";
                }
                SqlCommand cmd = new SqlCommand("Select Interests, Cohort, Summary, SoftSkills, Searchable, Email, PhotoLink, ContactPreference, " +
                                                "FirstName, LastName, Phone, Address, City, State, Postal_Code, [User].Id AS idOfUser, [Profile].Id AS profileId, Role " +
                                                "FROM [User] " +
                                                "JOIN Role ON Role.Id = [User].RoleId " +
                                                "LEFT JOIN [Profile] ON [Profile].UserId = [User].Id " +
                                                "LEFT JOIN [Address] ON [User].id = [Address].UserId " +
                                                "WHERE " + idType + " = @Id;", conn);
                cmd.Parameters.AddWithValue("@Id", id);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    profile = MapRowToProfile(reader);
                }
            }
            return profile;
        }

        private ProfileViewModel MapRowToProfile(SqlDataReader reader)
        {
            ProfileViewModel profile = new ProfileViewModel()
            {
                UserId = Convert.ToInt32(reader["idOfUser"]),
                Role = Convert.IsDBNull(reader["Role"]) ? "unknown" : Convert.ToString(reader["Role"]).ToLower(),
                Id = Convert.IsDBNull(reader["profileId"]) ? -1 : Convert.ToInt32(reader["profileId"]),
                Interests = Convert.IsDBNull(reader["Interests"]) ? "" : Convert.ToString(reader["Interests"]),
                Cohort = Convert.IsDBNull(reader["Cohort"]) ? -1 : Convert.ToInt32(reader["Cohort"]),
                Summary = Convert.IsDBNull(reader["Summary"]) ? "" : Convert.ToString(reader["Summary"]),
                SoftSkills = Convert.IsDBNull(reader["SoftSkills"]) ? "" : Convert.ToString(reader["SoftSkills"]),
                Searchable = Convert.IsDBNull(reader["Searchable"]) ? false : Convert.ToBoolean(reader["Searchable"]),
                Email = Convert.ToString(reader["Email"]),
                PhotoLink = Convert.IsDBNull(reader["PhotoLink"]) ? "" : Convert.ToString(reader["PhotoLink"]),
                ContactPreference = Convert.ToString(reader["ContactPreference"]),
                FirstName = Convert.IsDBNull(reader["FirstName"]) ? "" : Convert.ToString(reader["FirstName"]),
                LastName = Convert.IsDBNull(reader["LastName"]) ? "" : Convert.ToString(reader["LastName"]),
                Phone = Convert.IsDBNull(reader["Phone"]) ? "" : Convert.ToString(reader["Phone"]),
                Address = Convert.IsDBNull(reader["Address"]) ? "" : Convert.ToString(reader["Address"]),
                City = Convert.IsDBNull(reader["City"]) ? "" : Convert.ToString(reader["City"]),
                State = Convert.IsDBNull(reader["State"]) ? "" : Convert.ToString(reader["State"]),
                PostalCode = Convert.IsDBNull(reader["Postal_Code"]) ? "" : Convert.ToString(reader["Postal_Code"]),
            };

            return profile;
        }

        public int AddAddress(RegisterViewModel address)
        {
            int id = 0;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Address (UserId, Address, State, City, Postal_Code)" +
                    "VALUES (@UserId, @Address, @State, @City, @Postal_Code);" + SCOPE_IDENTITY_SQL, conn);
                cmd.Parameters.AddWithValue("@UserId", address.Id);
                cmd.Parameters.AddWithValue("@Address", address.UserAddress);
                cmd.Parameters.AddWithValue("@State", address.State);
                cmd.Parameters.AddWithValue("@City", address.City);
                cmd.Parameters.AddWithValue("@Postal_Code", address.PostalCode);
                id = (int)cmd.ExecuteScalar();
            }
            return id;
        }

        public Address GetAddress(int id)
        {
            Address address = new Address();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * FROM Address WHERE Id = @Id;", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    address = MapRowToAddress(reader);
                }
            }
            return address;
        }

        private Address MapRowToAddress(SqlDataReader reader)
        {
            Address address = new Address()
            {
                City = Convert.ToString(reader["City"]),
                State = Convert.ToString(reader["State"]),
                UserAddress = Convert.ToString(reader["Address"]),
                PostalCode = Convert.ToString(reader["Postal_code"])
            };
            return address;
        }

        #endregion Read methods

        #region Read Search Methods

        public List<StudentPreviewModel> GetSearchedProfileEmployer(Search search)
        {
            List<StudentPreviewModel> profileList = new List<StudentPreviewModel>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sqlString = "SELECT DISTINCT [User].FirstName, [User].LastName, [Profile].Cohort, " +
                    "[User].Email, [User].Phone, [Profile].ContactPreference, [User].id AS userId " +
                    "FROM [User] " +
                    "JOIN [Profile] ON [User].Id = [Profile].UserId " +
                    "LEFT JOIN CareerExperience ON [Profile].Id = CareerExperience.ProfileId " +
                    "LEFT JOIN Portfolio ON Portfolio.ProfileId = [Profile].Id " +
                    "LEFT JOIN Academics ON Academics.ProfileId = [Profile].Id " +
                    "LEFT JOIN PortfolioTech ON Portfolio.Id = PortfolioTech.PortfolioId " +
                    "LEFT JOIN TechName ON TechName.Id = PortfolioTech.TechNameId " +
                    "WHERE ([Profile].Searchable = 1 AND [Profile].Cohort > -1) ";
                List<string> searchList = new List<string>();

                if (search.Degree != null && search.Degree != "")
                {
                    searchList.Add(" Academics.Degree = @Degree ");
                }
                if (search.Cohort >= 0 && search.Cohort.ToString() != "")
                {
                    searchList.Add(" [Profile].Cohort = @Cohort ");
                }
                if (search.Industry != null && search.Industry != "")
                {
                    searchList.Add(" CareerExperience.Industry = @Industry ");
                }
                if (search.TechName != null && search.TechName != "")
                {
                    searchList.Add(" TechName.Name = @TechName ");
                }

                for (int i = 0; i < searchList.Count; i++)
                {
                    if (i > 0 && !search.ExOrIn)
                    {
                        sqlString += " OR ";
                    }
                    else if (i > 0 && search.ExOrIn)
                    {
                        sqlString += " AND ";
                    }
                    else if (i == 0)
                    {
                        sqlString += " AND ";
                    }
                    sqlString += searchList[i];
                }
                sqlString += " ORDER BY [Profile].Cohort DESC;";
                SqlCommand cmd = new SqlCommand(sqlString, conn);

                if (sqlString.Contains("@Cohort"))
                    cmd.Parameters.AddWithValue("@Cohort", search.Cohort);
                if (sqlString.Contains("@Industry"))
                    cmd.Parameters.AddWithValue("@Industry", search.Industry);
                if (sqlString.Contains("@TechName"))
                    cmd.Parameters.AddWithValue("@TechName", search.TechName);
                if (sqlString.Contains("@Degree"))
                    cmd.Parameters.AddWithValue("@Degree", search.Degree);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    profileList.Add(MapRowToStudentPreview(reader));
                }
            }

            return profileList;
        }

        public List<StudentPreviewModel> GetSearchedProfileStudentStaff(Search search)
        {
            List<StudentPreviewModel> profileList = new List<StudentPreviewModel>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sqlString = "SELECT DISTINCT [User].FirstName, [User].LastName, [Profile].Cohort, " +
                    "[User].Email, [User].Phone, [Profile].ContactPreference, [User].id AS userId " +
                    "FROM [User] " +
                    "JOIN [Profile] ON [User].Id = [Profile].UserId " +
                    "LEFT JOIN CareerExperience ON [Profile].Id = CareerExperience.ProfileId " +
                    "LEFT JOIN Portfolio ON Portfolio.ProfileId = [Profile].Id " +
                    "LEFT JOIN Academics ON Academics.ProfileId = [Profile].Id " +
                    "LEFT JOIN PortfolioTech ON Portfolio.Id = PortfolioTech.PortfolioId " +
                    "LEFT JOIN TechName ON TechName.Id = PortfolioTech.TechNameId ";
                List<string> searchList = new List<string>();

                if (search.Degree != null && search.Degree != "")
                {
                    searchList.Add(" Academics.Degree = @Degree ");
                }
                if (search.Cohort >= 0 && search.Cohort.ToString() != "")
                {
                    searchList.Add(" [Profile].Cohort = @Cohort ");
                }
                if (search.Industry != null && search.Industry != "")
                {
                    searchList.Add(" CareerExperience.Industry = @Industry ");
                }
                if (search.TechName != null && search.TechName != "")
                {
                    searchList.Add(" TechName.Name = @TechName ");
                }

                for (int i = 0; i < searchList.Count; i++)
                {
                    if (i > 0 && !search.ExOrIn)
                    {
                        sqlString += " OR ";
                    }
                    else if (i > 0 && search.ExOrIn)
                    {
                        sqlString += " AND ";
                    }
                    else if (i == 0)
                    {
                        sqlString += " WHERE ";
                    }
                    sqlString += searchList[i];
                }
                sqlString += " ORDER BY [Profile].Cohort DESC;";
                SqlCommand cmd = new SqlCommand(sqlString, conn);

                if (sqlString.Contains("@Cohort"))
                    cmd.Parameters.AddWithValue("@Cohort", search.Cohort);
                if (sqlString.Contains("@Industry"))
                    cmd.Parameters.AddWithValue("@Industry", search.Industry);
                if (sqlString.Contains("@TechName"))
                    cmd.Parameters.AddWithValue("@TechName", search.TechName);
                if (sqlString.Contains("@Degree"))
                    cmd.Parameters.AddWithValue("@Degree", search.Degree);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    profileList.Add(MapRowToStudentPreview(reader));
                }
            }

            return profileList;
        }

        #endregion Read Search Methods

        #region Read list methods

        public List<ProfileViewModel> GetProfileList(Security.BusinessLogic.Authorization auth)
        {
            List<ProfileViewModel> profileList = new List<ProfileViewModel>();
            if (auth.IsEmployer)
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT [User].FirstName, [User].LastName, [User].Email, [User].Phone, [Profile].Searchable FROM [User] " +
                        "JOIN Profile ON [User].Id = [Profile].UserId WHERE [Profile].Searchable = 1 AND [Profile].Cohort > -1;", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        profileList.Add(MapRowToProfileList(reader));
                    }
                }
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT [User].FirstName, [User].LastName, [User].Email, [User].Phone, [Profile].Searchable FROM [User] " +
                        "JOIN Profile ON [User].Id = [Profile].UserId;", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        profileList.Add(MapRowToProfileList(reader));
                    }
                }
            }
            return profileList;
        }

        private ProfileViewModel MapRowToProfileList(SqlDataReader reader)
        {
            return new ProfileViewModel()
            {
                FirstName = Convert.ToString(reader["User.FirstName"]),
                LastName = Convert.ToString(reader["User.LastName"]),
                Email = Convert.ToString(reader["User.Email"]),
                Phone = Convert.ToString(reader["User.Phone"])
            };
        }

        public List<Tech> GetProfileTechList(int id)
        {
            List<Tech> techList = new List<Tech>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT TechName.Name" +
                    "FROM [Profile]" +
                    "JOIN Portfolio ON Portfolio.ProfileId = [Profile].Id" +
                    "JOIN PortfolioTech ON Portfolio.Id = PortfolioTech.PortfolioId" +
                    "JOIN TechName ON TechName.Id = PortfolioTech.TechNameId" +
                    "WHERE [Profile].Id = @ProfileId", conn);

                cmd.Parameters.AddWithValue("@ProfileId", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    techList.Add(MapRowToTech(reader));
                }
            }
            return techList;
        }

        private Tech MapRowToTech(SqlDataReader reader)
        {
            return new Tech()
            {
                TechName = Convert.ToString(reader["Name"]),
            };
        }

        public List<Portfolio> GetPortfolioList(int id)
        {
            List<Portfolio> portfolioList = new List<Portfolio>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * FROM Portfolio WHERE ProfileId = @Id;", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    portfolioList.Add(MapRowToPortfolio(reader));
                }
            }
            return portfolioList;
        }

        public Portfolio GetPortfolio(int id)
        {
            Portfolio portfolio = new Portfolio();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * FROM Portfolio WHERE Id = @Id;", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    portfolio = MapRowToPortfolio(reader);
                }
            }
            return portfolio;
        }

        private Portfolio MapRowToPortfolio(SqlDataReader reader)
        {
            var port = new Portfolio()
            {
                Id = Convert.ToInt32(reader["Id"]),
                ProfileId = Convert.ToInt32(reader["ProfileId"]),
                ProjectTitle = Convert.ToString(reader["ProjectTitle"]),
                ProjectDescription = Convert.ToString(reader["ProjectDescription"]),
                ProjectLink = Convert.ToString(reader["ProjectLink"])
            };
            port.TechnologiesUsed = GetTechnologiesForPortfolioProject(port);
            return port;
        }

        private List<Tech> GetTechnologiesForPortfolioProject(Portfolio port)
        {
            var techList = new List<Tech>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select TechName.Name AS Name, TechName.Id AS Id FROM TechName " +
                                                "JOIN PortfolioTech ON TechName.Id = PortfolioTech.TechNameId " +
                                                "JOIN Portfolio ON PortfolioTech.PortfolioId = Portfolio.Id " +
                                                "WHERE PortfolioId = @Id;", conn);
                cmd.Parameters.AddWithValue("@Id", port.Id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    techList.Add(new Tech()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        TechName = Convert.ToString(reader["Name"])
                    });
                }
            }
            return techList;
        }

        public List<CareerExperience> GetCareerExperienceList(int id)
        {
            List<CareerExperience> careerList = new List<CareerExperience>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * FROM CareerExperience WHERE ProfileId = @Id;", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    careerList.Add(MapRowToCareerExperience(reader));
                }
            }
            return careerList;
        }

        public CareerExperience GetCareerExperience(int id)
        {
            CareerExperience career = new CareerExperience();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * FROM CareerExperience WHERE Id = @Id;", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    career = MapRowToCareerExperience(reader);
                }
            }
            return career;
        }

        private CareerExperience MapRowToCareerExperience(SqlDataReader reader)
        {
            return new CareerExperience()
            {
                Id = Convert.ToInt32(reader["Id"]),
                ProfileId = Convert.ToInt32(reader["ProfileId"]),
                Title = Convert.ToString(reader["Title"]),
                Employer = Convert.ToString(reader["Employer"]),
                Industry = Convert.ToString(reader["Industry"]),
                StartDate = Convert.ToDateTime(reader["StartDate"]),
                EndDate = Convert.ToDateTime(reader["EndDate"]),
                JobDescription = Convert.ToString(reader["JobDescription"])
            };
        }

        public List<Academics> GetAcademics(int id)
        {
            List<Academics> academicsList = new List<Academics>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * FROM Academics WHERE ProfileId = @Id;", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    academicsList.Add(MapRowToAcademics(reader));
                }
            }
            return academicsList;
        }

        public Academics GetAcademic(int id)
        {
            Academics academic = new Academics();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * FROM Academics WHERE Id = @Id;", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    academic = MapRowToAcademics(reader);
                }
            }
            return academic;
        }

        private Academics MapRowToAcademics(SqlDataReader reader)
        {
            return new Academics()
            {
                Id = Convert.ToInt32(reader["Id"]),
                ProfileId = Convert.ToInt32(reader["ProfileId"]),
                Degree = Convert.ToString(reader["Degree"]),
                Institution = Convert.ToString(reader["Institution"]),
                StartDate = Convert.ToDateTime(reader["StartDate"]),
                EndDate = Convert.ToDateTime(reader["EndDate"]),
                Graduated = Convert.ToBoolean(reader["Graduated"]),
                Major = Convert.ToString(reader["Major"])
            };
        }

        public List<StudentPreviewModel> GetRosterPreviews(bool onlySearchable)
        {
            List<StudentPreviewModel> studentList = new List<StudentPreviewModel>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sqlCommand = "Select FirstName, LastName, Email, Phone, ContactPreference, Cohort, [User].id AS userId " +
                                                "FROM Profile JOIN [User] ON [User].id = Profile.UserId ";
                if (onlySearchable)
                {
                    sqlCommand += " WHERE Searchable = 1 ";
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlCommand, conn);
                
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    studentList.Add(MapRowToStudentPreview(reader));
                }
            }
            return studentList;
        }

        private StudentPreviewModel MapRowToStudentPreview(SqlDataReader reader)
        {
            return new StudentPreviewModel
            {
                FirstName = Convert.ToString(reader["FirstName"]),
                LastName = Convert.ToString(reader["LastName"]),
                Email = Convert.ToString(reader["Email"]),
                Phone = Convert.ToString(reader["Phone"]),
                ContactPreference = Convert.ToString(reader["ContactPreference"]),
                Cohort = Convert.ToInt32(reader["Cohort"]),
                Id = Convert.ToInt32(reader["userId"]),
            };
        }

        public List<string> GetTechList()
        {
            List<string> techlist = new List<string>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select DISTINCT Name FROM TechName", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    techlist.Add(Convert.ToString(reader[0]));
                }
            }
            return techlist;
        }

        public List<string> GetIndustryList()
        {
            List<string> industryList = new List<string>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select DISTINCT Industry FROM CareerExperience", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    industryList.Add(Convert.ToString(reader[0]));
                }
            }
            return industryList;
        }

        public List<int> GetCohortNumList()
        {
            List<int> cohortList = new List<int>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select DISTINCT Cohort FROM Profile WHERE Cohort > -1;", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cohortList.Add(Convert.ToInt32(reader[0]));
                }
            }
            return cohortList;
        }

        public List<string> GetDegreeList()
        {
            List<string> degreeList = new List<string>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select DISTINCT Degree FROM Academics", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    degreeList.Add(Convert.ToString(reader[0]));
                }
            }
            return degreeList;
        }

        #endregion Read list methods

        #region updateMethods

        public void UpdatePortfolioProject(Portfolio portfolio)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Portfolio SET " +
                    "ProjectTitle = @ProjectTitle, " +
                    "ProjectDescription = @ProjectDescription, " +
                    "ProjectLink = @ProjectLink " +
                    "WHERE Id = @Id", conn);

                cmd.Parameters.AddWithValue("@ProjectTitle", portfolio.ProjectTitle);
                cmd.Parameters.AddWithValue("@ProjectDescription", portfolio.ProjectDescription);
                cmd.Parameters.AddWithValue("@ProjectLink", portfolio.ProjectLink);
                cmd.Parameters.AddWithValue("@Id", portfolio.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateAcademics(Academics academics)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Academics SET " +
                    "Degree = @Degree, " +
                    "Institution = @Institution, " +
                    "StartDate = @StartDate, " +
                    "EndDate = @EndDate, " +
                    "Graduated = @Graduated, " +
                    "Major = @Major " +
                    "WHERE Id = @Id", conn);

                cmd.Parameters.AddWithValue("@Degree", academics.Degree);
                cmd.Parameters.AddWithValue("@Institution", academics.Institution);
                cmd.Parameters.AddWithValue("@StartDate", academics.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", academics.EndDate);
                cmd.Parameters.AddWithValue("@Graduated", academics.Graduated);
                cmd.Parameters.AddWithValue("@Major", academics.Major);
                cmd.Parameters.AddWithValue("@Id", academics.Id);
                int rows = cmd.ExecuteNonQuery();
                if (rows == 0)
                {
                    throw new Exception("No rows affected");
                }
            }
        }

        public void UpdateCareerExperience(CareerExperience careerExperience)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE CareerExperience SET " +
                    "Title = @Title, " +
                    "Employer = @Employer, " +
                    "Industry = @Industry, " +
                    "StartDate = @StartDate, " +
                    "EndDate = @EndDate, " +
                    "JobDescription = @JobDescription " +
                    "WHERE Id = @Id", conn);

                cmd.Parameters.AddWithValue("@Title", careerExperience.Title);
                cmd.Parameters.AddWithValue("@Employer", careerExperience.Employer);
                cmd.Parameters.AddWithValue("@Industry", careerExperience.Industry);
                cmd.Parameters.AddWithValue("@StartDate", careerExperience.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", careerExperience.EndDate);
                cmd.Parameters.AddWithValue("@JobDescription", careerExperience.JobDescription);
                cmd.Parameters.AddWithValue("@Id", careerExperience.Id);
                int rows = cmd.ExecuteNonQuery();
                if(rows == 0)
                {
                    throw new Exception("exception");
                }
            }
        }

        public void UpdateProfile(ProfileViewModel vm)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Profile " +
                    "SET Searchable = @Searchable, " +
                    "Cohort = @Cohort, " +
                    "Summary = @Summary, " +
                    "SoftSkills = @SoftSkills, " +
                    "Interests = @Interests, " +
                    "PhotoLink = @PhotoLink, " +
                    "ContactPreference = @ContactPreference " +
                    "WHERE [Profile].Id= @Id;", conn);
                cmd.Parameters.AddWithValue("@Id", vm.Id);
                cmd.Parameters.AddWithValue("@Searchable", vm.Searchable);
                cmd.Parameters.AddWithValue("@Cohort", vm.Cohort);
                cmd.Parameters.AddWithValue("@Summary", vm.Summary);
                cmd.Parameters.AddWithValue("@SoftSkills", vm.SoftSkills);
                cmd.Parameters.AddWithValue("@Interests", vm.Interests);
                cmd.Parameters.AddWithValue("@PhotoLink", vm.PhotoLink);
                cmd.Parameters.AddWithValue("@ContactPreference", vm.ContactPreference);
                int rows = cmd.ExecuteNonQuery();
            }
        }

        public void UpdateUser(UserItem user)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE User SET " +
                    "FirstName = @FirstName, " +
                    "LastName = @LastName, " +
                    "Email = @Email, " +
                    "Phone = @Phone " +
                    "WHERE Id = @Id", conn);

                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Phone", user.Phone);
                cmd.Parameters.AddWithValue("@Id", user.Id);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdatePassword(UserItem user)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE User SET " +
                    "Hash = @Hash, " +
                    "Salt = @Salt " +
                    "WHERE Id = @Id", conn);

                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Hash", user.Hash);
                cmd.Parameters.AddWithValue("@Salt", user.Salt);

                cmd.ExecuteNonQuery();
            }
        }

        #endregion updateMethods

        #region DeleteMethods

        public void DeletePortfolioProject(int portfolioId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Portfolio WHERE Id = @Id;", conn);
                cmd.Parameters.AddWithValue("@Id", portfolioId);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteAcademicItem(int academicsId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Academics WHERE Id = @Id;", conn);
                cmd.Parameters.AddWithValue("@Id", academicsId);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCareerExperience(int careerId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM CareerExperience WHERE Id = @Id;", conn);
                cmd.Parameters.AddWithValue("@Id", careerId);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteUser(int userId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM User WHERE Id = @Id;", conn);
                cmd.Parameters.AddWithValue("@Id", userId);
                cmd.ExecuteNonQuery();
            }
        }

        #endregion DeleteMethods
    }
}