using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using BusinessLogic.Services;
using V08ClassLibrary.Entity;
using BusinessLogic.Services.AccountServices;
using BusinessLogic.Services.TrainingServices;

namespace V08.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly ITrainingService _trainingService; 
        public AccountController(IAccountService accountService,
                                 ITrainingService trainingService)
        {
            _accountService = accountService;
            _trainingService = trainingService;
        }
        [HttpPost]
        public ActionResult AuthenticateUser(Account account)
        {
            if (_accountService.Authenticated(account.EmployeeId, account.Password))
            {
                Session["Account"] = _accountService.GetAccount(account.EmployeeId);
                return Json(new { message = "Success" });
            }
            else
            {
                return Json(new { message = "Fail" });
            }; 
        }
        public ActionResult EmployeeViewPage()
        {
            if (Session.Contents.Count > 0)
            {
                ViewBag.Account = Session["Account"] as Account;
                return View();
            }
            else {return RedirectToAction("LogInPage");
            }
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
        public ActionResult RegisterUser(Account account)
        {
            if (_accountService.Duplicated(account.Email, account.NationalIdentificationNumber, account.MobileNumber)){
                return Json(new { message = "National identification number , mobile number or email has already been registered ! " });
            }
            else
            {
                _accountService.RegisterUser(account);
                Session["Account"] = _accountService.GetLastRegisteredAccount();
                return Json(new { message = "Success" });
            }
        }
        [HttpGet]
        public ActionResult GetTrainingList()
        {
            return Json((Session["Account"], _trainingService.GetTrainingList()) , JsonRequestBehavior.AllowGet );
        }
        [HttpPost]
        public ActionResult LogUserOut()
        {
            Session.Abandon();
            return Json(new { message = "Success" });
        }
    }
}