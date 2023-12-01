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
        private readonly IAccountDal _accDal;
        public AccountService(IAccountDal accDal)
        {
            _accDal = accDal;
        }
        public void Add(IAccount acc)
        {
            _accDal.Add(acc);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IAccount Get(int id)
        {
            return _accDal.Get(id);
        }

        public IEnumerable<IAccount> GetAll()
        {
            return _accDal.GetAll();  
        }

        public string tester()
        {
            return "User service  - all ok" + _accDal.tester();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
