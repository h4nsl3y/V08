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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult log()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(Account acc)
        {
            int id = acc.EmployeeId; 
            string password = acc.Password;
            if (_userBL.LogIn(id, password))
            {
                return Json(new { message = "Success" });
            }
            else return Json(new { message = "Fail" });

        }

        [HttpPost]
        public ActionResult GetData(Account acc)
        {
            _userBL.Register(acc);
            return Json(new { message = "Success" });
        }



        public ActionResult EmployeeView()
        {
            //IEnumerable <ITraining> trainings = _userBL.GetTrainingList();
            return View();
        }

        public ActionResult TestView()
        {
            return View();
        }


    }
}