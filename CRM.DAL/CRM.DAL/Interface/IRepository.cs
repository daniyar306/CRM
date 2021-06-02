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
     
        void Create(IEnumerable<T> item);

        void Create(T item);
        void Update(T item);
        void Delete(int? id);

    }
}
