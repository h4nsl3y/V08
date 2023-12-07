using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V08ClassLibrary.Repositories.TrainingRepositories;
using V08DataAccessLayer.DAL;
using V08DataAccessLayer.Entity;

namespace V08DataAccessLayer.Repository.TrainingRepositories
{
    public class TrainingRepository : ITrainingRepository , ITrainingManagementRepository
    {
        private readonly IDataAcessLayer _dataAccessLayer;
        public TrainingRepository(IDataAcessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }
        public bool Add(Training training)
        {
        string query = $"INSERT INTO TRAINING(title ,departmentId ,prerequisite ," +
                                              $"seatNumber ,deadline ,startDate," +
                                              $"endDate,shortDescription, LongDescription )" +
                                              $"VALUES (@TrainingId, @Title, @DepartmentId, " +
                                              $"@Prerequisite, @SeatNumber, @Deadline" +
                                              $"@ShortDescription, @LongDescription) ; ";
            List<SqlParameter> parameters = GetSqlParameter(training);
            return _dataAccessLayer.AffectedRows(query, parameters);
        }
        public bool Delete(int id)
        {
            string query = $"DELETE FROM TRAINING WHERE TRAININGID = {id} ; ";
            return _dataAccessLayer.AffectedRows(query);
        }
        public Training Get(int id)
        {
            string query = $"SELECT * FROM TRAINING WHERE TRAININGID ={id} ; ";
            return _dataAccessLayer.ExecuteQuery<Training>(query).First();
        }
        public IEnumerable<Training> GetAll()
        {
            string query = $"SELECT * FROM TRAINING; ";
            return _dataAccessLayer.ExecuteQuery<Training>(query);
        }

        public IEnumerable<Training> GetUnenrolled(int employeeId)
        {
            string query = $"SELECT * FROM TRAINING WHERE TRAININGID NOT IN " +
                           $"( SELECT TRAININGID FROM ENROLLMENT WHERE EMPLOYEEID = {employeeId}) ;";
            return _dataAccessLayer.ExecuteQuery<Training>(query);
        }

        public bool Update(Training training)
        {
            string query = $"UPDATE TRAINING " +
                           $"set title = @Title ,departmentId = @DepartmentId ,prerequisite = @Prerequisite ," +
                           $"seatNumber = @SeatNumber, deadline = @Deadline, startDate = @StartDate ," +
                           $"endDate = @EndDate ,shortDescription = @ShortDescription, LongDescription = @LongDescription " +
                           $"WHERE TRAININGID = @TrainingId ; ";
            List<SqlParameter> parameters = GetSqlParameter(training);
            return _dataAccessLayer.AffectedRows(query, parameters);
        }
        private List<SqlParameter> GetSqlParameter(Training training)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@TrainingId", training.TrainingId));
            list.Add(new SqlParameter("@Title", training.Title));
            list.Add(new SqlParameter("@DepartmentId", training.DepartmentId));
            list.Add(new SqlParameter("@Prerequisite", training.Prerequisite));
            list.Add(new SqlParameter("@SeatNumber", training.SeatNumber));
            list.Add(new SqlParameter("@Deadline", training.Deadline));
            list.Add(new SqlParameter("@StartDate", training.StartDate));
            list.Add(new SqlParameter("@EndDate", training.EndDate));
            list.Add(new SqlParameter("@Deadline", training.Deadline));
            list.Add(new SqlParameter("@ShortDescription", training.ShortDescription));
            list.Add(new SqlParameter("@LongDescription", training.LongDescription));
            return list;
        }
    }
}
