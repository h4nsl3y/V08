using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using V08ClassLibrary.Entity;
using V08ClassLibrary.Services;

namespace V08.BusinessLogic
{
    public class AccountBusinessLogic : IAccountBusinessLogic
    {
        private readonly IAccountService _userService;
        private readonly ITrainingService _trainingService;

        public AccountBusinessLogic(IAccountService userService, ITrainingService trainingService)
        {
            _userService = userService;
            _trainingService = trainingService;
        }

        public bool LogIn(int id, string password)
        {
            IAccount user = _userService.Get(id);
            return (user == null || user.Password != password) ? false: true;
        }
        public IEnumerable<ITraining> GetTrainingList() 
        {
            return _trainingService.GetAll();
        }

        public void Register(IAccount acc)
        {
            _userService.Add(acc);
        }
        public bool checkDuplicate(string value)
        {
            throw new NotImplementedException();
        }

   
    }
}