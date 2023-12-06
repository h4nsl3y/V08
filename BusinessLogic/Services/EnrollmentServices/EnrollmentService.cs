using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V08DataAccessLayer.Entity;
using V08DataAccessLayer.Repository.EnrollmentRepositories;

namespace BusinessLogic.Services.EnrollmentServices
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        public EnrollmentService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }
        public bool Add(Enrollment enrollment)
        {
            return _enrollmentRepository.Add(enrollment);
        }
        public bool Delete(int id)
        {
            return _enrollmentRepository.Delete(id);
        }

        public Enrollment Get(int id)
        {
            return _enrollmentRepository.Get(id);
        }

        public IEnumerable<Enrollment> GetAll()
        {
            return _enrollmentRepository.GetAll();
        }

        public bool Update(Enrollment enrollment)
        {
            return _enrollmentRepository.Update(enrollment);   
        }
    }
}
