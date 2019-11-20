using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkGeekMVC.Models
{
    public class ParkViewModel
    {
        public IList<Park> ParkList { get; set; }
        public IList<Weather> FiveDayForeCast { get; set; } = new List<Weather>();
        public Park Park { get; set; }
        public string WeatherWarningForecast(string forecast)
        {
                string result = "";
                if (forecast == "snow")
                {
                    result = "Make sure to bring your snow apparel";
                }
                if (forecast == "rain")
                {
                    result = "Bring an umbrella or rain jacket";
                }
                if (forecast == "thunderstorms")
                {
                    result = "No hiking today";
                }
                if (forecast == "sunny")
                {
                    result = "Make sure to wear sunscreen";
                }
                
                if (forecast == "cloudy")
                {
                    result = "Watch for lowering clouds at high elevation";
                }
                if (forecast == "partly cloudy")
                {
                    result = "Perfect day for hiking";
                }
            return result;
        }
        public string WeatherPicString(string forecast)
        {
            string result = forecast;
            
            if(forecast == "partly cloudy")
            {
                result = "partlyCloudy";
            }
            
            return result;
        }
        public int ConvertTempC(int temp)
        {
            temp = (int)((temp - 32) / 1.8);
            return temp;
        }
    }
}
