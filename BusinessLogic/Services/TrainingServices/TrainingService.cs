using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V08ClassLibrary.Repositories.TrainingRepositories;
using V08DataAccessLayer.Entity;
using V08DataAccessLayer.Repository.TrainingRepositories;

namespace BusinessLogic.Services.TrainingServices
{
    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _trainingRepository;
        private readonly ITrainingManagementRepository _trainingManagementRepository;
        public TrainingService(ITrainingRepository trainingRepository, ITrainingManagementRepository trainingManagementRepository)
        {
            _trainingRepository = trainingRepository;
            _trainingManagementRepository = trainingManagementRepository;
        }

        public bool Add(Training training)
        {
            return _trainingRepository.Add(training);
        }

        public bool Delete(int id)
        {
            return _trainingRepository.Delete(id);
        }

        public Training Get(int id)
        {
            return _trainingRepository.Get(id);
        }

        public IEnumerable<Training> GetAll()
        {
            return _trainingRepository.GetAll();
        }

        public IEnumerable<Training> GetUnenrolled(int employeeId)
        {
            return _trainingManagementRepository.GetUnenrolled(employeeId);
        }

        public bool Update(Training training)
        {
            return _trainingRepository.Update(training);
        }
    }
}
