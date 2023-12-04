using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V08ClassLibrary.Entity;

namespace V08.BusinessLogic.AccountService
{
    public interface IAccountService
    {
        bool AccountExist();
        IEnumerable<Training> GetTrainingList();
        bool Authenticated(int id, string password);
        bool Duplicated(string email,string NationalIdentificationNumber , int mobileNumber);
        Account GetAccount(int id);
        Account GetLastRegisteredAccount();
        void RegisterUser(Account account);
    }
}
