using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V08ClassLibrary.Entity;
using V08ClassLibrary.Repository.TrainingRepositories;

namespace BusinessLogic.Services.TrainingServices
{
    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _trainingRepository;
        public TrainingService(ITrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }

        public IEnumerable<Training> GetTrainingList()
        {
            try
            {
                return _trainingRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
