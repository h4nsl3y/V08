using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V08ClassLibrary.DatabaseUtil;
using V08ClassLibrary.Entity;

namespace V08ClassLibrary.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly IDataAcessLayer _dataAccessLayer;
        public EnrollmentRepository(IDataAcessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }
        public void Add(IEnrollment enrollment)
        {
            string query = $"INSERT INTO ENROLLMENT(EnrollmentId ,EmployeeId ,TrainingId ,[Status] ,SubmissionDate)" +
                          $"VALUES (@EnrollmentId ,@EmployeeId ,@TrainingId ,@Status ,@SubmissionDate)";
            List<SqlParameter> parameters = GetSqlParameter(enrollment);
            _dataAccessLayer.ExecuteQuery<Enrollment>(query, parameters);
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public IEnrollment Get(int id)
        {
            string query = $"SELECT * FROM ENROLLMENT WHERE ENROLLMENTID = {id}";
            return _dataAccessLayer.ExecuteQuery<Enrollment>(query).First();
        }
        public IEnumerable<IEnrollment> GetAll()
        {
            string query = $"SELECT * FROM ENROLLMENT";
            return _dataAccessLayer.ExecuteQuery<Enrollment>(query);
        }
        public void Update(IAccount user)
        {
            throw new NotImplementedException();
        }
        private List<SqlParameter> GetSqlParameter(IEnrollment enrollment)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@EnrollmentId", enrollment.EnrollmentId));
            list.Add(new SqlParameter("@EmployeeId", enrollment.EmployeeId));
            list.Add(new SqlParameter("@TrainingId", enrollment.TrainingId));
            list.Add(new SqlParameter("@Status", enrollment.Status));
            list.Add(new SqlParameter("@SubmissionDate", enrollment.SubmissionDate));
            return list;
        }
    }
}
