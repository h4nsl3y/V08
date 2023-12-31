﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using V08ClassLibrary.Entity;
using V08ClassLibrary.Services;

namespace V08.BusinessLogic.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly IAccountService _accountService;
        private readonly ITrainingService _trainingService;

        public AccountService(IAccountService accountService, ITrainingService trainingService)
        {
            _accountService = accountService;
            _trainingService = trainingService;
        }
        public bool AccountExist()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Training> GetTrainingList()
        {
            {
                return _trainingService.GetAll();
            }            
        }
        public bool Authenticated(int id, string password)
        {
            return _accountService.Authenticated(id, password);
        }
        public bool Duplicated(string email, string NationalIdentificationNumber, int mobileNumber)
        {
            return _accountService.Duplicated(email, NationalIdentificationNumber, mobileNumber);
        }
        public Account GetAccount(int id)
        {
            return _accountService.Get(id);
        }
        public void RegisterUser(Account account)
        {
            _accountService.Add(account);
        }

        public Account GetLastRegisteredAccount()
        {
            return _accountService.GetLast();
        }




    }
}