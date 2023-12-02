using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V08ClassLibrary.Entity;

namespace V08ClassLibrary.DataAccessLayer
{
    public interface IAccountRepository
    {
        void Add(Account account);
        void Delete(int id);
        void Update(Account account);
        Account Get(int id);
        bool Authenticated(int id, string password);
        IEnumerable<Account> GetAll();
     
    }
}
