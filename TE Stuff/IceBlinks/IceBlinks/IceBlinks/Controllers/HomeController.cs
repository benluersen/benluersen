using IceBlinks.Models;
using IceBlinks.Models.DAO;
using Lecture.Web.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Security.BusinessLogic;
using Security.DAO;
using System.Collections.Generic;
using System.Diagnostics;

namespace IceBlinks.Controllers
{
    public class HomeController : AuthenticationController
    {
        private IUserSecurityDAO _db = null;
        private IStudentProfileBuilderDAO _profileDb = null;

        public HomeController(IUserSecurityDAO db, IStudentProfileBuilderDAO profileDb, IHttpContextAccessor httpContext) : base(db, httpContext)
        {
            _db = db;
            _profileDb = profileDb;
        }

        private RosterViewModel GetSearchOptions(RosterViewModel rosterVM)
        {
            rosterVM.CohortList = new List<SelectListItem>();
            rosterVM.CohortList.Add(new SelectListItem("Any", ""));
            foreach (int cohort in _profileDb.GetCohortNumList())
            {
                SelectListItem item = new SelectListItem();
                item.Text = cohort.ToString();
                rosterVM.CohortList.Add(item);
            }

            rosterVM.DegreeList = new List<SelectListItem>();
            rosterVM.DegreeList.Add(new SelectListItem("Any", ""));
            foreach (string degree in _profileDb.GetDegreeList())
            {
                SelectListItem item = new SelectListItem();
                item.Text = degree;
                rosterVM.DegreeList.Add(item);
            }

            rosterVM.TechList = new List<SelectListItem>();
            rosterVM.TechList.Add(new SelectListItem("Any", ""));
            foreach (string tech in _profileDb.GetTechList())
            {
                SelectListItem item = new SelectListItem();
                item.Text = tech;
                rosterVM.TechList.Add(item);
            }

            rosterVM.IndustryList = new List<SelectListItem>();
            rosterVM.IndustryList.Add(new SelectListItem("Any", ""));
            foreach (string industry in _profileDb.GetIndustryList())
            {
                SelectListItem item = new SelectListItem();
                item.Text = industry;
                rosterVM.IndustryList.Add(item);
            }
            return rosterVM;
        }

        public IActionResult Index()
        {
            var usrMgr = GetUserManager();
            ViewData["currentUser"] = usrMgr.User;
            bool onlySearchable = false;
            if (usrMgr.IsAuthenticated)
            {
                var auth = new Authorization(usrMgr.User);
                if (auth.IsEmployer)
                {
                    onlySearchable = true;
                }
            }
            var rosterVM = new RosterViewModel();
            GetSearchOptions(rosterVM);
            
            var profileList = _profileDb.GetRosterPreviews(onlySearchable);
            rosterVM.StudentPreviewList = profileList;
            return GetAuthenticatedView("RosterView", rosterVM);
        }

        public IActionResult SearchRoster(RosterViewModel vm)
        {
            var usrMgr = GetUserManager();
            ViewData["currentUser"] = usrMgr.User;

            Search search = new Search();
            search.Cohort = vm.Cohort;
            search.Degree = vm.Degree;
            search.Industry = vm.Industry;
            search.TechName = vm.TechName;
            search.ExOrIn = vm.ExclusiveSearch;

            List<StudentPreviewModel> profileList = null;
            if (usrMgr.IsAuthenticated && usrMgr.User.RoleId == 3)
            {
                profileList = _profileDb.GetSearchedProfileEmployer(search);
            }
            else
            {
                profileList = _profileDb.GetSearchedProfileStudentStaff(search);
            }
            vm.StudentPreviewList = profileList;
            GetSearchOptions(vm);
            
            return GetAuthenticatedView("RosterView", vm);
        }

        public IActionResult About()
        {
            var usrMgr = GetUserManager();
            ViewData["currentUser"] = usrMgr.User;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}