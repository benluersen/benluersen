using Capstone.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Capstone.Tests 
{
    [TestClass]
    public class CampgroundSQLDALTests : NpServicesDAO
    {


        NpServicesDAO dao = new NpServicesDAO();

        [DataTestMethod]
        [DataRow("1", 3)]
        [DataRow("2", 3)]
        [DataRow("3", 1)]
        public void GetCampSitesTest(string parkId, int numCamps)
        {
            List<Campground> campgrounds = dao.getCampgrounds(parkId);
            Assert.AreEqual(numCamps, campgrounds.Count);

        }

      

    }
}
