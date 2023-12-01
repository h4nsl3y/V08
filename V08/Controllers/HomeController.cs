using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using V08ClassLibrary.Entity;
using V08ClassLibrary.Services;

namespace V08.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAccountService _userService;
        public HomeController(IAccountService userService)
        {
            _userService = userService;
        }
/*        User user = new User()
        {
            FirstName = "aaa",
            OtherName = " ",
            LastName = "bbb",
            Nic = "ccc",
            MobileNumber = 123457,
            Email = "somethin2@gmail.com"
        };*/

        public ActionResult Index()
        {
            string res =  _userService.Get(1).Email;
            //return View();
            //_baseService.Add(user);
            return Content(res);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}