using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using V08DataAccessLayer.DAL;
using V08DataAccessLayer.Entity;

namespace V08DataAccessLayer.Repository.AccountRepositories
{
    public class AccountRepository : IAccountRepository , IAccountManagementRepository
    {
        private readonly IDataAcessLayer _dataAccessLayer;
        public AccountRepository(IDataAcessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }
        public bool Add(Account account)
        {
            string query = $"INSERT INTO ACCOUNT (FirstName ,OtherName ,LastName ,NationalIdentificationNumber ,MobileNumber ,Email )" +
                           $"VALUES (@FirstName, @OtherName, @LastName, @NationalIdentificationNumber, @MobileNumber, @Email) ;";
            List<SqlParameter> parameters = GetSqlParameter(account);
            return _dataAccessLayer.AffectedRows(query, parameters);
        }
        public bool Authenticated(string email, string password)
        {
            string query = $"SELECT * FROM ACCOUNT WHERE EMAIL = '{email}' AND PASSWORD = '{password}' ; ";
            return (_dataAccessLayer.ExecuteQuery<Account>(query).Count() > 0);
        }
        public bool Delete(int id)
        {
            string query = $"DELETE FROM ACCOUNT WHERE EMPLOYEEID  = {id} ; ";
            return _dataAccessLayer.AffectedRows(query);
        }
        public bool Duplicated(string email, string NationalIdentificationNumber, int mobileNumber)
        {
            string query = $"SELECT * FROM ACCOUNT " +
                           $"WHERE EMAIL = '{email}' " +
                           $"OR NATIONALIDENTIFICATIONNUMBER = '{NationalIdentificationNumber}' " +
                           $"OR MOBILENUMBER = {mobileNumber} ; ";

            return (_dataAccessLayer.ExecuteQuery<Account>(query).Count() > 0);
        }
        public Account Get(int id)
        {
            string query = $"SELECT * FROM  ACCOUNT WHERE EMPLOYEEID = {id} ; ";
            return _dataAccessLayer.ExecuteQuery<Account>(query).First();
        }
        public Account GetAccount(string email)
        {
            string query = $"SELECT * FROM ACCOUNT WHERE EMAIL = '{email}' ; ";
            return _dataAccessLayer.ExecuteQuery<Account>(query).First();
        }
        public IEnumerable<Account> GetAll()
        {
            string query = $"SELECT * FROM ACCOUNT ; ";
            return _dataAccessLayer.ExecuteQuery<Account>(query);
        }
        public Account GetLast()
        {
            string query = $"SELECT TOP 1 * FROM ACCOUNT ORDER BY EMPLOYEEID DESC; ";
            return _dataAccessLayer.ExecuteQuery<Account>(query).First();
        }
        public bool Update(Account account)
        {
            string query = $"UPDATE ACCOUNT" +
                           $"SET FirstName = @FirstName ,OtherName = @OtherName ,LastName = @LastName ," +
                           $"NationalIdentificationNumber = @NationalIdentificationNumber ,MobileNumber @MobileNumber,Email = @Email " +
                           $"WHERE  EMPLOYEEID = @EmployeeId ; ";
            List<SqlParameter> parameters = GetSqlParameter(account);
            return _dataAccessLayer.AffectedRows(query, parameters);
        }
        private List<SqlParameter> GetSqlParameter(Account account)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@FirstName", account.FirstName));
            list.Add(new SqlParameter("@OtherName", account.OtherName ?? (object)DBNull.Value));
            list.Add(new SqlParameter("@LastName", account.LastName));
            list.Add(new SqlParameter("@NationalIdentificationNumber", account.NationalIdentificationNumber));
            list.Add(new SqlParameter("@MobileNumber", account.MobileNumber));
            list.Add(new SqlParameter("@Email", account.Email));
            list.Add(new SqlParameter("@EmployeeId", account.EmployeeId));
            return list;
        }
    }
}
