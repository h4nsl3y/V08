using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V08ClassLibrary.Entity;

namespace V08ClassLibrary.Services
{
    public interface IAccountService
    {
        void Add(Account user);
        void Delete(int id);
        void Update(int id);
        Account Get(int id);
        IEnumerable<Account> GetAll();
        bool Authenticated(int id, string password);
    }
}
