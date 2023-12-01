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
        public void Add(Training training)
        {
            _trainingRepository.Add(training);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Training Get(int id)
        {
            return _trainingRepository.Get(id);
        }

        public IEnumerable<Training> GetAll()
        {
            return _trainingRepository.GetAll();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
