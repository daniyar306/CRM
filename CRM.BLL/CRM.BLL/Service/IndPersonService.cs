using CRM.BLL.DTO;
using CRM.BLL.Infrastructure;
using CRM.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CRM.BLL.Service
{
    public class IndPersonService: ContragentService<IndividualPerson>
    {
        private static IndPersonService instance;

        private static object syncRoot = new Object();

        public static IndPersonService getInstance(string constring)
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new IndPersonService(constring);
                }
            }
            return instance;
        }

        protected IndPersonService(string constring) : base(constring)
        {

        }

        public override IEnumerable<IndividualPerson> GetAll(bool type)
        {
          
                if (repository.GetAll() != null)
                    if (type)
                        return repository.GetAll().OrderBy(x => x.LastName).ThenBy(x => x.Name).ThenBy(x => x.SecondName);
                    else
                        return repository.GetAll();
                else
                    return null;
          

        }

        public override void Delete(int? id)
        {
           
           if(id!=null)
            {
                var list=repository.GetAll().ToList();
               var result=list.Where(x=>x.Id!=id);

                Create(result);
            }
           
        }

        public override void Update(IndividualPerson item)
        {
            var list = repository.GetAll().ToList();
            var result = list.Where(x => x.Id != item.Id).ToList();
            result.Add(item);
            Create(result);
        }

        public override void Create(IndividualPerson contragents)
        {
            
                if (contragents != null)
                {

                    if (GetAll(false) != null)
                    {
                        if (GetAll(false).SingleOrDefault(x => x.Id == contragents.Id) != null)
                            throw new ValidationException($"Запись с Ид: {contragents.Id} уже существует", "");
                        else
                        repository.Create(contragents);

                    }
                    else
                    {
                        repository.Create(contragents);
                    }

                }
          
        }
    }
}
