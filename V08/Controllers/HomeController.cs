using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using V08ClassLibrary.Entity;
using V08ClassLibrary.Services;
using V08ClassLibrary.Test;

namespace V08.Controllers
{
    public class HomeController : Controller
    {
        private readonly test1 _t1;
        private readonly IAccountService _userService;
        public HomeController(test1 t1, IAccountService userService)
        {
            _t1 = t1;
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