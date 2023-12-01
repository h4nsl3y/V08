using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V08ClassLibrary.DatabaseUtil;
using V08ClassLibrary.Entity;

namespace V08ClassLibrary.DataAccessLayer
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDataAcessLayer _dataAccessLayer;
        public AccountRepository(IDataAcessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }
        public void Add(IAccount user)
        {
            string query = $"INSERT INTO [USER](FirstName ,OtherName ,LastName ,Nic ,MobileNumber ,Email )" +
                           $"VALUES (@FirstName, @OtherName, @LastName, @Nic, @MobileNumber, @Email)";
            List<SqlParameter> parameters = GetSqlParameter(user);
            _dataAccessLayer.ExecuteQuery<Account>(query, parameters);
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public IAccount Get(int id)
        {
            string query = $"Select * from userView where EmployeeId  = {id} ; ";
            return _dataAccessLayer.ExecuteQuery<Account>(query).First();
        }
        public IEnumerable<IAccount> GetAll()
        {
            string query = $"Select * from userView ";
            return _dataAccessLayer.ExecuteQuery<Account>(query);
        }
        public void Update(IAccount user)
        {
            throw new NotImplementedException();
        }

        public string tester()
        {
            return "DAL - all ok";
        }
        public List<SqlParameter> GetSqlParameter(IAccount user)
        {
            List<SqlParameter> list = new List<SqlParameter>();

            list.Add(new SqlParameter("@FirstName", user.FirstName));
            list.Add(new SqlParameter("@OtherName", user.OtherName));
            list.Add(new SqlParameter("@LastName", user.LastName));
            list.Add(new SqlParameter("@Nic", user.Nic));
            list.Add(new SqlParameter("@MobileNumber", user.MobileNumber));
            list.Add(new SqlParameter("@Email", user.Email));

            return list;
        }


    }
}
