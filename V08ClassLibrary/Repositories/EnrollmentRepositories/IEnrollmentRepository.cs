using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V08DataAccessLayer.Entity;

namespace V08DataAccessLayer.Repository.EnrollmentRepositories
{
    public interface IEnrollmentRepository
    {
        bool Add(Enrollment enrollment);
        bool Delete(int id);
        bool Update(Enrollment enrollment);
        Enrollment Get(int id);
        IEnumerable<Enrollment> GetAll();
    }
}
