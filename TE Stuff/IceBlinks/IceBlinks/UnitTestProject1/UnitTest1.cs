using IceBlinks.Models;
using IceBlinks.Models.DAO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IceBlinksTest
{
    [TestClass]
    public class UnitTest1
    {
        #region items
        private IStudentProfileBuilderDAO _db = null;
        public UnitTest1()
        {
            _db = new StudentProfileBuilderSqlDAO("Data Source=localhost\\sqlexpress;Initial Catalog=IceBlinks;Integrated Security=True");
        }
        CareerExperience exp = new CareerExperience()
        {
            Employer = "christian",
            JobDescription = "christian's favorite",
            Industry = "christianism",
            StartDate = Convert.ToDateTime("11/11/1199"),
            EndDate = Convert.ToDateTime("12/12/1919"),
            Title = "ceochristian"
        };
        Academics academics = new Academics()
        {
            Degree = "Bachelors of Christian",
            Graduated = true,
            StartDate = Convert.ToDateTime("12/12/1244"),
            EndDate = Convert.ToDateTime("12/12/1555"),
            Institution = "University of Christian christianson",
            Major = "spaghetti and christian"

        };
        Profile profile = new Profile()
        {

        };

        #endregion
        #region Create Tests


        [TestMethod]
        public void aTest()
        {
        }

    }
}

#endregion