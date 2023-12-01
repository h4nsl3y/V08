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
        public void Add(IAccount acc)
        {
            _accountRepository.Add(acc);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IAccount Get(int id)
        {
            return _accountRepository.Get(id);
        }

        public IEnumerable<IAccount> GetAll()
        {
            return _accountRepository.GetAll();  
        }

        public string tester()
        {
            return "User service  - all ok" + _accountRepository.tester();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
