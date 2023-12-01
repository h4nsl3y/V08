using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V08ClassLibrary.Entity;

namespace V08ClassLibrary.Services
{
    public interface IEnrollmentService
    {
        void Add(Enrollment enrollment);
        void Delete(int id);
        void Update(int id);
        Enrollment Get(int id);
        IEnumerable<Enrollment> GetAll();
    }
}
