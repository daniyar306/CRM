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
        void Create(IEnumerable<T> item);
        void Create(T item);
        void Update(T item);
        void Delete(int? id);

    }
}
