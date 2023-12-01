using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V08ClassLibrary.DataAccessLayer;
using V08ClassLibrary.Entity;

namespace V08ClassLibrary.Services
{
    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _trainingRepository;
        public TrainingService(ITrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }
        public void Add(ITraining training)
        {
            _trainingRepository.Add(training);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ITraining Get(int id)
        {
            return _trainingRepository.Get(id);
        }

        public IEnumerable<ITraining> GetAll()
        {
            return _trainingRepository.GetAll();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
