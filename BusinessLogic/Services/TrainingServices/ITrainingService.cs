using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V08DataAccessLayer.Entity;

namespace BusinessLogic.Services.TrainingServices
{
    public interface ITrainingService
    {
        bool Add(Training training);
        bool Delete(int id);
        bool Update(Training training);
        Training Get(int id);
        IEnumerable<Training> GetAll();
    }
}
