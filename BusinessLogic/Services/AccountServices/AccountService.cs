using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V08DataAccessLayer.Entity;
using V08DataAccessLayer.Repository.AccountRepositories;
using V08DataAccessLayer.Repository.TrainingRepositories;

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
        public bool Add(Account account)
        {
            return _accountRepository.Add(account);
        }
        public bool Authenticated(string email, string password)
        {
            return _accountManagementRepository.Authenticated(email, password);
        }
        public bool Delete(int id)
        {
            return _accountRepository.Delete(id);
        }
        public bool Duplicated(string email, string NationalIdentificationNumber, int mobileNumber)
        {
            return _accountManagementRepository.Duplicated(email, NationalIdentificationNumber, mobileNumber);
        }
        public Account GetAccount(int id)
        {
            return _accountRepository.Get(id);
        }
        public Account GetAccount(string email)
        {
            return _accountManagementRepository.GetAccount(email);
        }
        public IEnumerable<Account> GetAll()
        {
            throw new NotImplementedException();
        }
        public Account GetLastRegisteredAccount()
        {
            return _accountManagementRepository.GetLast();
        }
        public bool Update(Account account)
        {
            throw new NotImplementedException();
        }
    }
}