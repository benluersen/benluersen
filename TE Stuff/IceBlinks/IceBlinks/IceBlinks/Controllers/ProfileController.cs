using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IceBlinks.Models;
using IceBlinks.Models.DAO;
using Lecture.Web.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Security.BusinessLogic;
using Security.DAO;
using Security.Models;
using Security.Models.Database;

namespace IceBlinks.Controllers
{
    public class ProfileController : AuthenticationController
    {
        private IUserSecurityDAO _securityDb;
        private IStudentProfileBuilderDAO _db;
        public ProfileController(IUserSecurityDAO securitydb, IStudentProfileBuilderDAO db, IHttpContextAccessor httpContext) : base(securitydb, httpContext)
        {
            _securityDb = securitydb;
            _db = db;
        }

        [HttpGet]
        public IActionResult ProfileEdit()
        {
            IActionResult result = RedirectToAction("Index");
            var usrMgr = GetUserManager();
            
            ViewData["currentUser"] = usrMgr.User;
            
            try
            {
                var profile = _db.GetProfile(usrMgr.User.Id, true);
                profile.AcademicsList = _db.GetAcademics(profile.Id);
                profile.CareerExperienceList = _db.GetCareerExperienceList(profile.Id);
                profile.PortfolioProjects = _db.GetPortfolioList(profile.Id);
                result = GetAuthenticatedView("ProfileEdit", profile);
            }
            catch (Exception)
            {

            }

            return result;
        }

        [HttpPost]
        public IActionResult ProfileEdit(ProfileViewModel vm)
        {
            var usrMgr = GetUserManager();
            if (usrMgr.User != null)
            {
                vm.UserId = usrMgr.User.Id;
                vm.Id = _db.GetProfile(vm.UserId, true).Id;
            }
            try
            {
                _db.UpdateProfile(vm);
                TempData["StatusMessage"] = "Profile Update Successful";
            }
            catch (Exception)
            {
                TempData["StatusMessage"] = "Profile Update Failed";
            }
            return RedirectToAction("ProfileEdit");
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            IActionResult result = RedirectToAction("Login","Login");
            ChangePasswordViewModel passChange = new ChangePasswordViewModel();
            var usrMgr = GetUserManager();
            ViewData["currentUser"] = usrMgr.User;

            if (usrMgr.IsAuthenticated)
            {
                var profile = _db.GetProfile(usrMgr.User.Id, true);
                passChange.UserId = usrMgr.User.Id;
                result = VerifyUserView("UpdatePassword", profile.Id, passChange);
            }
            return result;
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel vm)
        {
            IActionResult result = RedirectToAction("Login","Login");
            try
            {
                var user = _securityDb.GetUserItem(vm.UserId);
                var auth = new Authentication(vm.OldPassword, user.Salt);
                var profile = _db.GetProfile(vm.UserId, true);
                if (ModelState.IsValid && auth.Hash == user.Hash && vm.UserId == user.Id)
                {
                    auth = new Authentication(vm.NewPassword);
                    user.Hash = auth.Hash;
                    user.Salt = auth.Salt;
                    _securityDb.UpdateUserItem(user);
                    profile.AcademicsList = _db.GetAcademics(vm.UserId);
                    profile.CareerExperienceList = _db.GetCareerExperienceList(vm.UserId);
                    profile.PortfolioProjects = _db.GetPortfolioList(vm.UserId);
                    result = VerifyUserView("ProfileEdit", profile.Id, profile);
                }
                else
                {
                    ChangePasswordViewModel passChange = new ChangePasswordViewModel();
                    result = VerifyUserView("UpdatePassword", profile.Id, passChange);
                }
            }
            catch (Exception)
            {

            }

            return result;
        }

        public IActionResult Profile(int id)
        {
            var profile = _db.GetProfile(id, true);
            profile.AcademicsList = _db.GetAcademics(profile.Id);
            profile.CareerExperienceList = _db.GetCareerExperienceList(profile.Id);
            profile.PortfolioProjects = _db.GetPortfolioList(profile.Id);

            var user = GetUserManager().User;

            ViewData["currentUser"] = user;
            if (user != null)
            {
                ViewData["UserAuthorized"] = id == user.Id;
            }

            IActionResult view = GetAuthenticatedView("ProfileView", profile);
            
            return view;
        }

        [HttpGet]
        public IActionResult AddCareer()
        {
            var usrMgr = GetUserManager();

            ViewData["currentUser"] = usrMgr.User;

            CareerExperience exp = new CareerExperience();
            return GetAuthenticatedView("NewCareer", exp);
        }

        [HttpGet]
        public IActionResult EditCareer(int id)
        {
            IActionResult result = null;
            var usrMgr = GetUserManager();
            ViewData["currentUser"] = usrMgr.User;

            try
            {
                var career = _db.GetCareerExperience(id);
                result = GetAuthenticatedView("NewCareer", career);
            }
            catch
            {
                result = RedirectToAction("AddCareer");
            }
            return result;
        }

        [HttpPost]
        public IActionResult AddCareer(CareerExperience exp)
        {
            var usrmgr = GetUserManager();
            IActionResult result = GetAuthenticatedView("NewCareer", exp);
            var profileId = _db.GetProfile(usrmgr.User.Id, true).Id;
            exp.ProfileId = profileId;
            if(ModelState.IsValid)
            {
            try
            {
                _db.UpdateCareerExperience(exp);
                result = RedirectToAction("ProfileEdit");
            }
            catch (Exception)
            {
                try
                {
                    _db.AddCareer(exp);
                    result = RedirectToAction("ProfileEdit");
                }
                catch
                {

                }
            }
            }

            return result;
        }

        [HttpGet]
        public IActionResult DeleteCareer(int id)
        {
            IActionResult result = RedirectToAction("ProfileEdit");
            if (ModelState.IsValid)
            {
                try
                {
                    _db.DeleteCareerExperience(id);
                }
                catch (Exception)
                {
                    //failed message here
                }
            }
            return result;
        }

        [HttpGet]
        public IActionResult AddPortfolioProject()
        {
            var usrMgr = GetUserManager();
            ViewData["currentUser"] = usrMgr.User;

            Portfolio port = new Portfolio();
            return GetAuthenticatedView("NewProject", port);
        }

        [HttpGet]
        public IActionResult EditPortfolioProject(int id)
        {
            IActionResult result = null;
            var usrMgr = GetUserManager();
            ViewData["currentUser"] = usrMgr.User;

            try
            {
                var port = _db.GetPortfolio(id);
                result = GetAuthenticatedView("NewProject", port);
            }
            catch
            {
                result = RedirectToAction("AddPortfilioProject");
            }
            return result;
        }

        [HttpPost]
        public IActionResult AddPortfolioProject(Portfolio port)
        {
            var usrmgr = GetUserManager();
            IActionResult result = GetAuthenticatedView("NewProject", port);
            port.ProfileId = _db.GetProfile(usrmgr.User.Id, true).Id;
            if (ModelState.IsValid)
            {
                try
                {
                    _db.UpdatePortfolioProject(port);
                    result = RedirectToAction("ProfileEdit");
                }
                catch (Exception)
                {
                    try
                    {
                        _db.AddPortfolio(port);
                        result = RedirectToAction("ProfileEdit");
                    }
                    catch (Exception)
                    {

                    }
                }
                
            }
            return result;
        }

        [HttpGet]
        public IActionResult DeletePortfolioProject(int id)
        {
            IActionResult result = RedirectToAction("ProfileEdit");
            if (ModelState.IsValid)
            {
                try
                {
                    _db.DeletePortfolioProject(id);
                }
                catch (Exception)
                {
                    //failed message here
                }
            }
            return result;
        }

        [HttpGet]
        public IActionResult AddAcademics()
        {
            var usrMgr = GetUserManager();
            ViewData["currentUser"] = usrMgr.User;

            Academics acad = new Academics();
            acad.ProfileId = _db.GetProfile(usrMgr.User.Id).Id;
            return GetAuthenticatedView("NewAcademics", acad);
        }

        [HttpGet]
        public IActionResult EditAcademics(int id)
        {
            IActionResult result = null;
            var usrMgr = GetUserManager();
            ViewData["currentUser"] = usrMgr.User;

            try
            {
                var acad = _db.GetAcademic(id);
                result = GetAuthenticatedView("NewAcademics", acad);
            }
            catch
            {
                result = RedirectToAction("AddAcademics");
            }
            return result;
        }

        [HttpPost]
        public IActionResult AddAcademics(Academics acad)
        {
            var usrmgr = GetUserManager();
            IActionResult result = GetAuthenticatedView("NewAcademics", acad);
            acad.ProfileId = _db.GetProfile(usrmgr.User.Id, true).Id;
            if (ModelState.IsValid)
            {
                try
                {
                    _db.UpdateAcademics(acad);
                    result = RedirectToAction("ProfileEdit");

                }
                catch (Exception)
                {
                    try
                    {
                        
                        _db.AddAcademics(acad);
                        result = RedirectToAction("ProfileEdit");
                    }
                    catch
                    {

                    }
                }
            }
            return result;
        }

        [HttpGet]
        public IActionResult DeleteAcademics(int id)
        {
            IActionResult result = RedirectToAction("ProfileEdit");
            if (ModelState.IsValid)
            {
                try
                {
                    _db.DeleteAcademicItem(id);
                }
                catch (Exception)
                {
                    //failed message here
                }
            }
            return result;
        }



        /// <summary>
        /// Check if user is allowed to view the page.
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="profileId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        private IActionResult VerifyUserView(string viewName, int profileId, object model = null)
        {
            IActionResult result = null;
            UserItem user = GetSessionData<UserItem>(USER_KEY);
            var authorize = new Authorization(user);

            if (authorize.IsAdministrator || profileId == _db.GetProfile(user.Id, true).Id)
            {
                result = View(viewName, model);
            }
            else
            {
                result = RedirectToAction("Index", "Home");
            }
            return result;
        }
    }
}