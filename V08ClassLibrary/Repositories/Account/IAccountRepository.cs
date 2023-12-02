﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V08ClassLibrary.Entity;

namespace V08ClassLibrary.DataAccessLayer
{
    public interface IAccountRepository
    {
        void Add(Account account);
        bool Authenticated(int id, string password);
        void Delete(int id);
        bool Duplicated(string email, string NationalIdentificationNumber, int mobileNumber);
        void Update(Account account);
        Account Get(int id);
        IEnumerable<Account> GetAll();
        Account GetLast();
    }
}
