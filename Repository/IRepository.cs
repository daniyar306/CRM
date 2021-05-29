using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Repository
{
   public interface IRepository<T> 
    {
      
        IEnumerable<T> Read();

        void Write(IEnumerable<T> records);
    }
}
