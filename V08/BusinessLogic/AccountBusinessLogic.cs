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
        private readonly IAccountService _accountService;
        private readonly ITrainingService _trainingService;

        public AccountBusinessLogic(IAccountService accountService, ITrainingService trainingService)
        {
            _accountService = accountService;
            _trainingService = trainingService;
        }
        public bool AccountExist()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<ITraining> GetTrainingList()
        {
            return _trainingService.GetAll();
        }
        public bool IsCrednetialValid(int id, string password)
        {
            return _accountService.IsCrednetialValid(id, password);
        }
        public bool IsDuplicate(string field, string value)
        {
            throw new NotImplementedException();
        }
        public void RegisterUser(IAccount acc)
        {
            _accountService.Add(acc);
        }



    }
}