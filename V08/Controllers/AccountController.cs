using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using BusinessLogic.Services;
using V08DataAccessLayer.Entity;
using BusinessLogic.Services.AccountServices;
using BusinessLogic.Services.TrainingServices;

namespace V08.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost]
        public ActionResult AuthenticateUser(Account account)
        {
            if (_accountService.Authenticated(account.Email, account.Password))
            {
                Session["Account"] = _accountService.GetAccount(account.Email);
                return Json(new { message = "Success" });
            }
            else
            {
                return Json(new { message = "Fail" });
            }; 
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
               if(_accountService.Add(account))
                {
                    Session["Account"] = _accountService.GetLastRegisteredAccount();
                    return Json(new { message = "Success" });
                }
                else
                {
                    return Json(new { message = "Failed" });
                }
            }
        }
        [HttpPost]
        public ActionResult LogUserOut()
        {
            Session.Abandon();
            return Json(new { message = "Success" });
        }
    }
}