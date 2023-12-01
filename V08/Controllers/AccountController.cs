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
        private readonly IAccountBusinessLogic _accountBL;
        public AccountController(IAccountBusinessLogic userBL)
        {
            _accountBL = userBL;
        }
        [HttpPost]
        public ActionResult AuthenticateUser(Account acc)
        {
            int id = acc.EmployeeId;
            string password = acc.Password;
            return (_accountBL.Authenticated(id, password)) ? Json(new { message = "Success" }) : Json(new { message = "Fail" });
        }
        public ActionResult EmployeeViewPage()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LogInPage()
        {
            return View();
        }

        public ActionResult RegisterPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(Account acc)
        {
            _accountBL.RegisterUser(acc);
            return Json(new { message = "Success" });
        }
/*      [HttpGet]
 *      public JsonResult GetTrainingList()
        {
            return Json(_userBL.GetTrainingListJson);
        }*/
    }
}