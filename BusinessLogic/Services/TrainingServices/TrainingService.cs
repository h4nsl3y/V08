using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V08DataAccessLayer.Entity;
using V08DataAccessLayer.Repository.TrainingRepositories;

namespace BusinessLogic.Services.TrainingServices
{
    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _trainingRepository;
        public TrainingService(ITrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;
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

        public bool Update(Training training)
        {
            return _trainingRepository.Update(training);
        }
    }
}
