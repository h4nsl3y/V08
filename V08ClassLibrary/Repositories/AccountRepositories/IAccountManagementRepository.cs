using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V08ClassLibrary.Entity;

namespace V08ClassLibrary.Repository.AccountRepositories
{
    public interface IAccountManagementRepository
    {
        bool Authenticated(int id, string password);
        Account GetLast();
    }
}
