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
    
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            return RedirectToAction("LogInPage", "Account");
        }
        [CustomSessionState]
        [CustomAuthorization(EnumRole.Employee)]
        public ActionResult EmployeeViewPage()
        {
            return View(Session["Account"]);
        }
        [CustomSessionState]
        [CustomAuthorization(EnumRole.Manager)]
        public ActionResult ManagerViewPage()
        {
            return View(Session["Account"]);
        }
        [CustomSessionState]
        [CustomAuthorization(EnumRole.Administrator)]
        public ActionResult AdministratorViewPage()
        {
            return View(Session["Account"]);
        }
        public ActionResult RegisterEnrollment()
        {
            return RedirectToAction("Enrollment", "RegisterEnrollment");
        }
    }
}