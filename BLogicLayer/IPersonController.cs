using CRM.Model;
using CRM.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLogicLayer
{
    public abstract class IPersonController<T> where T : class
    {
        public static IRepository<T> repository;
       
        public IPersonController(string FileNameCSV)
        {
            repository = new Repository<T>(FileNameCSV);
        
        }

        public abstract IEnumerable<T> Get_Contragents();

        public  void Set_Contragents(IEnumerable<T> contragents)
        {

            try
            {
                if(contragents!=null)
                repository.Write(contragents);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

    }
}
