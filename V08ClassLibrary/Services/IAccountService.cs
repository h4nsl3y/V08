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
        void Add(IAccount user);
        void Delete(int id);
        void Update(int id);
        IAccount Get(int id);
        IEnumerable<IAccount> GetAll();

        string tester();
    }
}
