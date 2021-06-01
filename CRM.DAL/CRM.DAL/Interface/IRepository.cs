using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DAL.Interface
{
     public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(IEnumerable<T> item);

        void Create(T item);
        void Update(T item);
        void Delete(T item);

    }
}
