using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V08ClassLibrary.Entity;

namespace V08ClassLibrary.Services
{
    public interface ITrainingService
    {
        void Add(ITraining training);
        void Delete(int id);
        void Update(int id);
        ITraining Get(int id);
        IEnumerable<ITraining> GetAll();
    }
}
