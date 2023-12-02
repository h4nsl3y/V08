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
    public class TrainingRepository : ITrainingRepository
    {
        private readonly IDataAcessLayer _dataAccessLayer;
        public TrainingRepository(IDataAcessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }
        public void Add(Training training)
        {
        string query = $"INSERT INTO TRAINING(title ,departmentId ,prerequisite ," +
                                              $"seatNumber ,deadline ,startDate," +
                                              $"endDate,shortDescription, LongDescription )" +
                                              $"VALUES (@TrainingId, @Title, @DepartmentId, " +
                                              $"@Prerequisite, @SeatNumber, @Deadline" +
                                              $"@ShortDescription, @LongDescription) ; ";
            List<SqlParameter> parameters = GetSqlParameter(training);
            _dataAccessLayer.ExecuteQuery<Training>(query, parameters);
        }
        public void Delete(int id)
        {
            string query = $"DELETE FROM TRAINING WHERE TRAININGID = {id} ; ";
            _dataAccessLayer.ExecuteQuery<Training>(query).First();
        }
        public Training Get(int id)
        {
            string query = $"SELECT * FROM TRAININGVIEW WHERE TRAININGID ={id} ; ";
            return _dataAccessLayer.ExecuteQuery<Training>(query).First();
        }
        public IEnumerable<Training> GetAll()
        {
            string query = $"SELECT * FROM TRAININGVIEW ; ";
            return _dataAccessLayer.ExecuteQuery<Training>(query);
        }
        public void Update(Training training)
        {
            string query = $"UPDATE TRAINING " +
                           $"set title = @Title ,departmentId = @DepartmentId ,prerequisite = @Prerequisite ," +
                           $"seatNumber = @SeatNumber, deadline = @Deadline, startDate = @StartDate ," +
                           $"endDate = @EndDate ,shortDescription = @ShortDescription, LongDescription = @LongDescription " +
                           $"WHERE TRAININGID = @TrainingId ; ";
            List<SqlParameter> parameters = GetSqlParameter(training);
            _dataAccessLayer.ExecuteQuery<Training>(query, parameters);
        }
        private List<SqlParameter> GetSqlParameter(Training training)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@TrainingId", training.TrainingId));
            list.Add(new SqlParameter("@Title", training.Title));
            list.Add(new SqlParameter("@DepartmentId", training.Department));
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
