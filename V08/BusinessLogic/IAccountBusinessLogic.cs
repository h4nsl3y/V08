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
        bool LogIn(int id, string password);

        IEnumerable<ITraining> GetTrainingList();
        void Register(IAccount acc);
        bool checkDuplicate(string value);
    }
}
