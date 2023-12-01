using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using V08.BusinessLogic;
using V08ClassLibrary.Entity;

namespace V08.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountBusinessLogic _userBL;
        public AccountController(IAccountBusinessLogic userBL)
        {
            _userBL = userBL;
        }
        public ActionResult EmployeeView()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetData(Account acc)
        {
            _userBL.RegisterUser(acc);
            return Json(new { message = "Success" });
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LogInPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(Account acc)
        {
            int id = acc.EmployeeId;
            string password = acc.Password;
            if (_userBL.IsCrednetialValid(id, password))
            {
                return Json(new { message = "Success" });
            }
            else return Json(new { message = "Fail" });
        }
        public ActionResult Register()
        {
            return View();
        }
    }
}