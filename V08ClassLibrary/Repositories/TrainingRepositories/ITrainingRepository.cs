using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V08DataAccessLayer.Entity;

namespace V08DataAccessLayer.Repository.TrainingRepositories
{
    public interface ITrainingRepository
    {
        bool Add(Training training);
        bool Delete(int id);
        bool Update(Training training);
        Training Get(int id);
        IEnumerable<Training> GetAll();
    }
}
