using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V08ClassLibrary.Entity;

namespace V08.BusinessLogic
{
    public interface IAccountBusinessLogic
    {
        bool AccountExist();
        IEnumerable<Training> GetTrainingList();
        bool Authenticated(int id, string password);
        bool Duplicated(string field, string value);
        void RegisterUser(Account account);
    }
}
