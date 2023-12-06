using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V08DataAccessLayer.Entity;

namespace V08DataAccessLayer.Repository.AccountRepositories
{
    public interface IAccountRepository
    {
        bool Add(Account account);
        bool Delete(int id);
        bool Update(Account account);
        Account Get(int id);
        IEnumerable<Account> GetAll();
    }
}
