using CRM.BLL.Interface;
using CRM.DAL.Interface;
using CRM.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL.Service
{
    public abstract class ContragentService<T>:IService<T> where T : class
    {
        public static IRepository<T> repository;
       
        public ContragentService(string constring)
        {
            repository = new CSVRepository<T>(constring);
        }

        public void Delete(T item)
        {
            repository.Delete(item);
        }
        public T Get(int id) 
        {
          return  repository.Get(id);     
        }
        public abstract IEnumerable<T> GetAll(bool type);
        public void Update(T item)
        {
            repository.Update(item);
        }
        public  void Create(IEnumerable<T> contragents)
        {

            try
            {
                if(contragents!=null)
                repository.Create(contragents);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        
    }
}
