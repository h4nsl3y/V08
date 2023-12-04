using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V08ClassLibrary.Entity;

namespace BusinessLogic.Services.TrainingServices
{
    public interface ITrainingService
    {
        IEnumerable<Training> GetTrainingList();
    }
}
