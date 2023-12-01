﻿using System;
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
        IEnumerable<ITraining> GetTrainingList();
        bool IsCrednetialValid(int id, string password);
        bool IsDuplicate(string field, string value);
        void RegisterUser(IAccount acc);
    }
}
