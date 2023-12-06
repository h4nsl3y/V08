using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace V08.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult PageNotFound()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RedirectHome()
        {
            return Json(new { redirectToUrl = Url.Action("EmployeeViewPage", "Account") });
        }
    }
}