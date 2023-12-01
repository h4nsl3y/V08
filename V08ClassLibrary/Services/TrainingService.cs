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
        private readonly ITrainingDal _trainingDal;
        public TrainingService(ITrainingDal trainingDal)
        {
            _trainingDal = trainingDal;
        }
        public void Add(ITraining training)
        {
            _trainingDal.Add(training);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ITraining Get(int id)
        {
            return _trainingDal.Get(id);
        }

        public IEnumerable<ITraining> GetAll()
        {
            return _trainingDal.GetAll();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
