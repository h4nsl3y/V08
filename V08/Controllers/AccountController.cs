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
        public AccountController(IAccountBusinessLogic accountBL)
        {
            _accountBL = accountBL;
        }
        [HttpPost]
        public ActionResult AuthenticateUser(Account account)
        {
            if (_accountBL.Authenticated(account.EmployeeId, account.Password))
            {
                Session["Account"] = _accountBL.GetAccount(account.EmployeeId);
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
            if (_accountBL.Duplicated(account.Email, account.NationalIdentificationNumber, account.MobileNumber)){
                return Json(new { message = "National identification number , mobile number or email has already been registered ! " });
            }
            else
            {
                _accountBL.RegisterUser(account);
                Session["Account"] = _accountBL.GetLastRegisteredAccount();
                return Json(new { message = "Success" });
            }
        }
        [HttpGet]
        public ActionResult GetTrainingList()
        {
            var data = _accountBL.GetTrainingList();
            return Json((Session["Account"],_accountBL.GetTrainingList()) , JsonRequestBehavior.AllowGet );
        }
        [HttpPost]
        public ActionResult LogUserOut()
        {
            Session.Abandon();
            return Json(new { message = "Success" });
        }
    }
}