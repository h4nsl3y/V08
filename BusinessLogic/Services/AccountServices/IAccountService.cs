using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V08DataAccessLayer.Entity;

namespace BusinessLogic.Services.AccountServices
{
    public interface IAccountService
    {
        bool Add(Account account);
        bool Authenticated(string email, string password);
        bool Delete(int id);
        bool Duplicated(string email,string NationalIdentificationNumber , int mobileNumber);
        Account GetAccount(string email);
        IEnumerable<Account> GetAll();
        Account GetLastRegisteredAccount();
        bool Update(Account account);
    }
}
