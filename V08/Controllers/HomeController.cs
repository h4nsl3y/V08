using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using V08ClassLibrary.Custom;
using V08ClassLibrary.Enum;
using V08DataAccessLayer.Entity;

namespace V08.Controllers
{
    [CustomSessionState]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("LogInPage", "Account");
        }
        [CustomAuthorization(EnumRole.Employee)]
        public ActionResult EmployeeViewPage()
        {
             return View(Session["Account"]);
        }
        [CustomAuthorization(EnumRole.Manager)]
        public ActionResult ManagerViewPage()
        {
            return View(Session["Account"]);
        }
        [CustomAuthorization(EnumRole.Administrator)]
        public ActionResult AdministratorViewPage()
        {
            return View(Session["Account"]);
        }
        [HttpGet]
        public ActionResult GetTrainingList()
        {
            return RedirectToAction("GetTrainingList", "Training");
        }

    }
}