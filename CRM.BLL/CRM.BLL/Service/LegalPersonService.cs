using CRM.BLL.BussinesModels;
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
    public class LegalPersonService : ContragentService<LegalPerson>
    {
   
        private ContragentService<IndividualPerson> individualPersonsService;
       
        private static LegalPersonService instance;

        private static object syncRoot = new Object();

        public static LegalPersonService getInstance(string constring, ContragentService<IndividualPerson> _individualPersonsServic)
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new LegalPersonService(constring, _individualPersonsServic);
                }
            }
            return instance;
        }

        protected LegalPersonService(string constring, ContragentService<IndividualPerson> _individualPersonsService) : base(constring)
        {
            this.individualPersonsService = _individualPersonsService;
        }


        public override IEnumerable<LegalPerson> GetAll(bool type)
        {
          
                if (repository.GetAll() != null && individualPersonsService.GetAll(type) != null)
                {
                    return GetLegalPersons.Get_Persons(type, repository,individualPersonsService);
                }
                else
                    return null;
         
        }

        public override void Delete(int? id)
        {
            if (id != null)
            {
                var list = repository.GetAll().ToList();
                var result = list.Where(x => x.Id != id);

                Create(result);
            }
        }

        public override void Update(LegalPerson item)
        {
            var list = repository.GetAll().ToList();
            var result = list.Where(x => x.Id != item.Id).ToList();
            result.Add(item);
            Create(result);
        }

        public override void Create(LegalPerson contragents)
        {
            if (contragents != null)
            {

                if (GetAll(false) != null)
                {
                    if (GetAll(false).SingleOrDefault(x => x.Id == contragents.Id) != null)
                        throw new ValidationException($"Запись с Ид: {contragents.Id} уже существует","");
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
