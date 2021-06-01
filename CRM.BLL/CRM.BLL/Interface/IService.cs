using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL.Interface
{
    interface IService<T> where T : class
    {
        IEnumerable<T> GetAll(bool type);
        T Get(int id);
        void Create(IEnumerable<T> item);
        void Update(T item);
        void Delete(T item);

    }
}
