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
    public class AccountDal : IAccountDal
    {
        private readonly IDbUtils _dbUtils;
        public AccountDal(IDbUtils dbUtils)
        {
            _dbUtils = dbUtils;
        }
        public void Add(IAccount user)
        {
            string query = $"INSERT INTO [USER](FirstName ,OtherName ,LastName ,Nic ,MobileNumber ,Email )" +
                           $"VALUES (@FirstName, @OtherName, @LastName, @Nic, @MobileNumber, @Email)";
            List<SqlParameter> parameters = GetSqlParameter(user);
            _dbUtils.ExecuteQuery<Account>(query, parameters);
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public IAccount Get(int id)
        {
            string query = $"Select * from userView where EmployeeId  = {id} ; ";
            return _dbUtils.ExecuteQuery<Account>(query).First();
        }
        public IEnumerable<IAccount> GetAll()
        {
            string query = $"Select * from userView ";
            return _dbUtils.ExecuteQuery<Account>(query);
        }
/*        public IEnumerable<IUser> GetEntityList(DataTable table)
        {
            List<User> list = new List<User>();
            Object obj;
            foreach(DataRow row in table.Rows)
            {
                obj = GetEntity(row);
                list.Add((User)obj);
            }
            return list;
        }*/
 /*       public IUser GetEntity(DataRow row)
        {
            IUser user = new User()
            {
                EmployeeId = int.Parse(row["EmployeeId"].ToString()) ,
                FirstName = row["FirstName"].ToString(),
                OtherName = row["OtherName"].ToString(),
                LastName = row["LastName"].ToString(),
                Nic = row["Nic"].ToString(),
                MobileNumber = int.Parse(row["MobileNumber"].ToString()),
                Email = row["Email"].ToString(),
                ManagerId = ValueCheck(row["ManagerId"].ToString()),
                DepartmentId = ValueCheck(row["DepartmentId"].ToString()),
                Password = row["Password"].ToString(),
                RoleId = int.Parse(row["RoleId"].ToString())
            };
            return (User)user;
        }*/
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
