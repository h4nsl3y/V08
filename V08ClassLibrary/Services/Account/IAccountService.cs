﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V08ClassLibrary.Entity;

namespace V08ClassLibrary.Services
{
    public interface IAccountService
    {
        void Add(Account user);
        bool Authenticated(int id, string password);
        void Delete(int id);
        bool Duplicated(string email, string NationalIdentificationNumber, int mobileNumber);
        void Update(int id);
        Account Get(int id);
        Account GetLast();
        IEnumerable<Account> GetAll();
    }
}
