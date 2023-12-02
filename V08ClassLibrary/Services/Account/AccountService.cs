using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V08ClassLibrary.DataAccessLayer;
using V08ClassLibrary.Entity;

namespace V08ClassLibrary.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public void Add(Account account)
        {
            _accountRepository.Add(account);
        }
        public bool Authenticated(int id, string password)
        {
           return _accountRepository.Authenticated(id, password);
        }
        public void Delete(int id)
        {
            _accountRepository.Delete(id);
        }

        public bool Duplicated(string email, string NationalIdentificationNumber, int mobileNumber)
        {
            return _accountRepository.Duplicated(email, NationalIdentificationNumber, mobileNumber);
        }

        public Account Get(int id)
        {
            return _accountRepository.Get(id);
        }
        public IEnumerable<Account> GetAll()
        {
            return _accountRepository.GetAll();  
        }

        public Account GetLast()
        {
            return _accountRepository.GetLast();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
       
    }
}
