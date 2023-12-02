using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using V08ClassLibrary.DatabaseUtil;
using V08ClassLibrary.Entity;
using V08ClassLibrary.Repositories.GenericRepository;

namespace V08ClassLibrary.DataAccessLayer
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDataAcessLayer _dataAccessLayer;
        public AccountRepository(IDataAcessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }
        public void Add(Account account)
        {
            string query = $"INSERT INTO [USER](FirstName ,OtherName ,LastName ,NationalIdentificationNumber ,MobileNumber ,Email )" +
                           $"VALUES (@FirstName, @OtherName, @LastName, @NationalIdentificationNumber, @MobileNumber, @Email) ;";
            List<SqlParameter> parameters = GetSqlParameter(account);
            _dataAccessLayer.ExecuteQuery<Account>(query, parameters);
        }
        public bool Authenticated(int id, string password)
        {
            string query = $"SELECT * FROM USERVIEW WHERE EMPLOYEEID  = {id} AND PASSWORD = '{password}' ; ";
            return _dataAccessLayer.ExecuteQuery<Account>(query).Count() > 0;
        }
        public void Delete(int id)
        {
            string query = $"DELETE FROM [USER] WHERE EMPLOYEEID  = {id} ; ";
            _dataAccessLayer.ExecuteQuery<Account>(query);
        }
        public bool Duplicated(string email, string NationalIdentificationNumber, int mobileNumber)
        {
            string query = $"SELECT * FROM USERVIEW " +
                           $"WHERE EMAIL = '{email}' " +
                           $"OR NATIONALIDENTIFICATIONNUMBER = '{NationalIdentificationNumber}' " +
                           $"OR MOBILENUMBER = {mobileNumber} ; ";

            return _dataAccessLayer.ExecuteQuery<Account>(query).Count > 0;
        }
        public Account Get(int id)
        {
            string query = $"SELECT * FROM USERVIEW WHERE EMPLOYEEID  = {id} ; ";
            return _dataAccessLayer.ExecuteQuery<Account>(query).First();
        }
        public IEnumerable<Account> GetAll()
        {
            string query = $"SELECT * FROM USERVIEW ; ";
            return _dataAccessLayer.ExecuteQuery<Account>(query);
        }
        public Account GetLast()
        {
            string query = $"SELECT TOP 1 * FROM USERVIEW ORDER BY EMPLOYEEID DESC; ";
            return _dataAccessLayer.ExecuteQuery<Account>(query).First();
        }
        public void Update(Account account)
        {
            string query = $"UPDATE [USER]" +
                           $"SET FirstName = @FirstName ,OtherName = @OtherName ,LastName = @LastName ," +
                           $"NationalIdentificationNumber = @NationalIdentificationNumber ,MobileNumber @MobileNumber,Email = @Email " +
                           $"WHERE  EMPLOYEEID = @EmployeeId ; ";
            List<SqlParameter> parameters = GetSqlParameter(account);
            _dataAccessLayer.ExecuteQuery<Account>(query, parameters);
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
