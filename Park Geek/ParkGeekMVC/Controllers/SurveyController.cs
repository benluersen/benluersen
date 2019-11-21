using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParkGeek;
using ParkGeekMVC.Models;
using Security.DAO;

namespace ParkGeekMVC.Controllers
{
    public class SurveyController : AuthenticationController
    {
        IParkGeekDAO _db;

        public SurveyController(IUserSecurityDAO db, IHttpContextAccessor httpContext, IParkGeekDAO daodb) : base(db, httpContext)
        {
            _db = daodb;
        }

        public IActionResult AddNewSurvey()
        {
            SurveyViewModel vm = new SurveyViewModel();
            var listOfParks = _db.GetAllParks();
            foreach(var park in listOfParks)
            {
                SelectListItem item = new SelectListItem();
                item.Text = park.ParkName;
                item.Value = park.ParkCode;
                vm.ParkNames.Add(item);
            }
            return GetAuthenticatedView("PostSurvey", vm);
        }
        
        [HttpPost]
        public IActionResult AddNewSurvey(SurveyViewModel surveyViewModel)
        {
            _db.AddNewSurvey(surveyViewModel.Survey);
            var parkSurveyList = _db.GetSurveyParkList();

            return RedirectToAction("Index", parkSurveyList);
        }

      

        [HttpGet]
        public IActionResult Index()
        {
            
            var parkSurveyList = _db.GetSurveyParkList();
           
            return GetAuthenticatedView("Index", parkSurveyList);

        }
    
    }
}