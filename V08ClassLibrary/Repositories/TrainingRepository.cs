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
        private readonly IDataAcessLayer _dbUtils;
        public TrainingRepository(IDataAcessLayer dbUtils)
        {
            _dbUtils = dbUtils;
        }
        public void Add(ITraining training)
        {
        string query = $"INSERT INTO TRAINING(title ,departmentId ,prerequisite ," +
                                              $"seatNumber ,deadline ,startDate," +
                                              $"endDate,shortDescription, LongDescription )" +
                                              $"VALUES (@TrainingId, @Title, @DepartmentId, " +
                                              $"@Prerequisite, @SeatNumber, @Deadline" +
                                              $"@ShortDescription, @LongDescription)";
            List<SqlParameter> parameters = GetSqlParameter(training);
            _dbUtils.ExecuteQuery<Training>(query, parameters);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ITraining Get(int id)
        {
            string query = $"Select * from trainingView where trainingID ={id}";
            return _dbUtils.ExecuteQuery<Training>(query).First();
        }

        public IEnumerable<ITraining> GetAll()
        {
            string query = $"Select * from trainingView ";
            return _dbUtils.ExecuteQuery<Training>(query);
        }

/*        public ITraining GetEntity(DataRow row)
        {

        }

        public IEnumerable<ITraining> GetEntityList(DataTable table)
        {
            throw new NotImplementedException();
        }*/

        public void Update(ITraining user)
        {
            throw new NotImplementedException();
        }

        public List<SqlParameter> GetSqlParameter(ITraining training)
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
