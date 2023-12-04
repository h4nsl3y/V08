using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V08ClassLibrary.Entity;
using V08ClassLibrary.Repository.AccountRepositories;
using V08ClassLibrary.Repository.TrainingRepositories;

namespace BusinessLogic.Services.AccountServices
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountManagementRepository _accountManagementRepository;


        public AccountService(IAccountRepository accountRepository,IAccountManagementRepository accountManagementRepository)
        {
            _accountRepository = accountRepository;
            _accountManagementRepository = accountManagementRepository;
        }
        public bool AccountExist()
        {
            throw new NotImplementedException();
        }

        public bool Authenticated(int id, string password)
        {
            return _accountManagementRepository.Authenticated(id, password);
        }
        public bool Duplicated(string email, string NationalIdentificationNumber, int mobileNumber)
        {
            return _accountRepository.Duplicated(email, NationalIdentificationNumber, mobileNumber);
        }
        public Account GetAccount(int id)
        {
            return _accountRepository.Get(id);
        }
        public void RegisterUser(Account account)
        {
            _accountRepository.Add(account);
        }
        public Account GetLastRegisteredAccount()
        {
            return _accountManagementRepository.GetLast();
        }
    }
}