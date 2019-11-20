using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkGeek;
using ParkGeek.DAL;
using ParkGeekMVC.Models;
using Security.DAO;

namespace ParkGeekMVC.Controllers
{
    public class ParkController : AuthenticationController
    {
        IParkGeekDAO _db;

        public ParkController(IUserSecurityDAO db, IHttpContextAccessor httpContext, IParkGeekDAO daodb) : base(db, httpContext)
        {
            _db = daodb;
        }

        public IActionResult Index()
        {
            var parkList = _db.GetAllParks();
            return GetAuthenticatedView("Index", parkList);
        }

        public IActionResult Detail(string parkCode)
        {

            ParkViewModel vm = new ParkViewModel();
            vm.Park = _db.GetPark(parkCode);
            vm.FiveDayForeCast = _db.GetFiveDayWeather(parkCode);
            return GetAuthenticatedView("Detail", vm);

            
        }

        
    }
}
