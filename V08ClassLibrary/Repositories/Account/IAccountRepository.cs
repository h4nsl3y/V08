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
        void Add(IAccount user);
        void Delete(int id);
        void Update(IAccount user);
        IAccount Get(int id);
        IEnumerable<IAccount> GetAll();
     
    }
}
