using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V08DataAccessLayer.Entity;

namespace V08ClassLibrary.Repositories.TrainingRepositories
{
    public interface ITrainingManagementRepository
    {
        IEnumerable<Training> GetUnenrolled(int employeeId);
    }
}
