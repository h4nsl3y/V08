using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V08ClassLibrary.DAL;
using V08ClassLibrary.Entity;
using V08ClassLibrary.Repositories.GenericRepository;

namespace V08ClassLibrary.Repository.EnrollmentRepositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly IDataAcessLayer _dataAccessLayer;
        public EnrollmentRepository(IDataAcessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }
        public void Add(Enrollment enrollment)
        {
            string query = $"INSERT INTO ENROLLMENT(EnrollmentId ,EmployeeId ,TrainingId ,[Status] ,SubmissionDate)" +
                           $"VALUES (@EnrollmentId ,@EmployeeId ,@TrainingId ,@Status ,@SubmissionDate) ; ";
            List<SqlParameter> parameters = GetSqlParameter(enrollment);
            _dataAccessLayer.ExecuteQuery<Enrollment>(query, parameters);
        }
        public void Delete(int id)
        {
            string query = $"DELETE FROM ENROLLMENT WHERE EMPLOYEEID  = {id} ; ";
            _dataAccessLayer.ExecuteQuery<Account>(query);
        }
        public Enrollment Get(int id)
        {
            string query = $"SELECT * FROM ENROLLMENT WHERE ENROLLMENTID = {id} ; ";
            return _dataAccessLayer.ExecuteQuery<Enrollment>(query).First();
        }
        public IEnumerable<Enrollment> GetAll()
        {
            string query = $"SELECT * FROM ENROLLMENT ; ";
            return _dataAccessLayer.ExecuteQuery<Enrollment>(query);
        }
        public void Update(Enrollment enrollment)
        {
            string query =$"UPDATE  ENROLLMENT" +
                          $"SET EmployeeId = @EmployeeId, TrainingId = @TrainingId, " +
                          $"[Status] = @Status , SubmissionDate = @SubmissionDate" +
                          $"WHERE EnrollmentId = @EnrollmentId, ; ";
            List<SqlParameter> parameters = GetSqlParameter(enrollment);
            _dataAccessLayer.ExecuteQuery<Enrollment>(query, parameters);
        }
        private List<SqlParameter> GetSqlParameter(Enrollment enrollment)
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
