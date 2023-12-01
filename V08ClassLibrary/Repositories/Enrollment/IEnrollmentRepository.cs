using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V08ClassLibrary.Entity;

namespace V08ClassLibrary.Repositories
{
    public interface IEnrollmentRepository
    {
        void Add(IEnrollment enrollment);
        void Delete(int id);
        void Update(IAccount user);
        IEnrollment Get(int id);
        IEnumerable<IEnrollment> GetAll();
    }
}
