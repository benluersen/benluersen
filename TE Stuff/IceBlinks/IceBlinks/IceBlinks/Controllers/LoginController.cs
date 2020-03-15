using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Security.BusinessLogic;
using Security.DAO;
using Security.Exceptions;
using Security.Models;
using Security.Models.Database;
using SessionControllerData;
using IceBlinks.Models;
using IceBlinks.Models.DAO;
using System.Transactions;

namespace Lecture.Web.Controllers
{
    public class LoginController : AuthenticationController
    {
        private const string LOGIN_ERROR = "The username or password are invalid.";
        private IStudentProfileBuilderDAO _profileDb;
        public LoginController(IUserSecurityDAO db, IStudentProfileBuilderDAO profileDb, IHttpContextAccessor httpContext) : base(db, httpContext)
        {
            _profileDb = profileDb;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            LogoutUser();
            return Redirect("/");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel vm)
        {
            IActionResult result = View();

            if (ModelState.IsValid)
            {
                try
                {
                    LoginUser(vm.Email, vm.Password);

                    result = RedirectToAction("Index", "Home");
                }
                catch (UserDoesNotExistException)
                {
                    ModelState.AddModelError("invalid-user", LOGIN_ERROR);
                }
                catch (PasswordMatchException)
                {
                    ModelState.AddModelError("invalid-user", LOGIN_ERROR);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("invalid-user", ex.Message);
                }
            }

            return result;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel vm)
        {
            IActionResult result = View();

            if (ModelState.IsValid)
            {
                
                try
                {
                    User user = new User();
                    user.FirstName = vm.FirstName;
                    user.LastName = vm.LastName;
                    user.Email = vm.Email;
                    user.Password = vm.Password;
                    user.ConfirmPassword = vm.ConfirmPassword;
                    user.Phone = vm.Phone;
                    user.RoleId = vm.RoleId;
                    using (TransactionScope tran = new TransactionScope())
                    {
                        vm.Id = RegisterUser(user);
                        _profileDb.AddAddress(vm);
                        if (user.RoleId == 2)
                        {
                            _profileDb.CreateProfile(vm.Id);
                        }
                        tran.Complete();
                    }
                    result = RedirectToAction("Index", "Home");
                }
                catch (UserExistsException)
                {
                    ModelState.AddModelError("invalid-user", "The username is already taken.");
                }
                catch (PasswordMatchException)
                {
                    ModelState.AddModelError("invalid-user", "The passwords do not match.");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("invalid-user", ex.Message);
                }
            }

            return result;
        }
    }
}