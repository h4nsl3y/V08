using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V08ClassLibrary.Entity;

namespace V08ClassLibrary.Repositories.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T item);
        void Delete(int id);
        void Update(T item);
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}
