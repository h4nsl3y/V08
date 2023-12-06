using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V08DataAccessLayer.Entity;

namespace BusinessLogic.Services.EnrollmentServices
{
    public interface IEnrollmentService
    {
        bool Add(Enrollment enrollment);
        bool Delete(int id);
        Enrollment Get(int id);
        IEnumerable<Enrollment> GetAll();
        bool Update(Enrollment enrollment);
    }
}
