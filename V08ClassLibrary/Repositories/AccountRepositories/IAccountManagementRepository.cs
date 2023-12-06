using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V08DataAccessLayer.Entity;

namespace V08DataAccessLayer.Repository.AccountRepositories
{
    public interface IAccountManagementRepository
    {
        bool Authenticated(string email, string password);
        bool Duplicated(string email, string NationalIdentificationNumber, int mobileNumber);
        Account GetLast();
        Account GetAccount(string email);
    }
}
