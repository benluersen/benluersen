using ParkGeek.DAL.Models;
using ParkGeekMVC.Models;
using System;
using System.Collections.Generic;

namespace ParkGeek
{
    public interface IParkGeekDAO
    {
        IList<Park> GetAllParks();
        Park GetPark(string parkCode);
        void AddNewSurvey(SurveyResult survey);
        IList<Weather> GetFiveDayWeather(string parkCode);
        IList<Surveys> GetSurveyParkList();
        
    }
}
