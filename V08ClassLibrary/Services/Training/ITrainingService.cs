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
        void Add(Training training);
        void Delete(int id);
        void Update(int id);
        Training Get(int id);
        IEnumerable<Training> GetAll();
    }
}
