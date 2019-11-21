using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkGeek;
using ParkGeek.DAL;
using ParkGeekMVC.Models;

namespace ParkGeekTests
{
    [TestClass]
    public class IntegrationTests
    {
        private IParkGeekDAO _db = null;
        [TestMethod]
        public void NumParksTests()
        {
            _db = new ParkGeekDAO("Data Source=localhost\\sqlexpress;Initial Catalog=NPGeekTest;Integrated Security=True");
            var numParks = _db.GetAllParks();
            Assert.AreEqual(10, numParks.Count);
        }

        [TestMethod]
        public void GetParkTest()
        {
            _db = new ParkGeekDAO("Data Source=localhost\\sqlexpress;Initial Catalog=NPGeekTest;Integrated Security=True");
            var testPark = _db.GetPark("CVNP");
            Assert.AreEqual("Cuyahoga Valley National Park", testPark.ParkName);
            Assert.AreEqual("Ohio", testPark.State);
            Assert.AreEqual(32832, testPark.Acreage);
            Assert.AreEqual(696, testPark.ElevationInFeet);
            Assert.AreEqual(125, testPark.MilesOfTrail);
            Assert.AreEqual(0, testPark.NumberOfCampsites);
            Assert.AreEqual("Woodland", testPark.Climate);
            Assert.AreEqual(2189849, testPark.AnnualVisitors);
            Assert.AreEqual("Of all the paths you take in life, make sure a few of them are dirt.", testPark.InspirationalQuote);
            Assert.AreEqual("John Muir", testPark.InspirationalQuoteSource);
            Assert.AreEqual("Though a short distance from the urban areas of Cleveland and Akron, Cuyahoga" +
                " Valley National Park seems worlds away. The park is a refuge for native plants and wildlife, and " +
                "provides routes of discovery for visitors. The winding Cuyahoga River gives way to deep forests, rolling " +
                "hills, and open farmlands. Walk or ride the Towpath " +
                "Trail to follow the historic route of the Ohio & Erie Canal", testPark.ParkDescription);
            Assert.AreEqual(0M, testPark.EntryFee);
            Assert.AreEqual(390, testPark.NumAnimalSpecies);
        }
        
        [TestMethod]
        public void NumWeatherTest()
        {
            _db = new ParkGeekDAO("Data Source=localhost\\sqlexpress;Initial Catalog=NPGeekTest;Integrated Security=True");
            var numWeather = _db.GetFiveDayWeather("CVNP");
            Assert.AreEqual(5, numWeather.Count);
        }

        [TestMethod]
        public void GetWeatherTest()
        {
            _db = new ParkGeekDAO("Data Source=localhost\\sqlexpress;Initial Catalog=NPGeekTest;Integrated Security=True");
            var weather = _db.GetFiveDayWeather("CVNP");
            Assert.AreEqual(38, weather[0].LowTemp);
            Assert.AreEqual(62, weather[0].HighTemp);
            Assert.AreEqual("rain", weather[0].Forecast);
        
        }
        [TestMethod]
        public void AddSurveyTest()
        {
            SurveyResult testSurvey = new SurveyResult()
            {
                ParkCode = "CVNP",
                Email = "b1@gmail.com",
                ActivityLevel = "Arduous",
                State = "KY"
            };
            bool result = _db.AddNewSurvey(testSurvey);
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void TempConverterTest()
        {
            ParkViewModel testVM = new ParkViewModel();
            Assert.AreEqual(0, testVM.ConvertTempC(32));
            Assert.AreEqual(100, testVM.ConvertTempC(212));
            Assert.AreEqual(-40, testVM.ConvertTempC(-40));
        }
    
    }
}
