using CRM.BLL.BussinesModels;
using CRM.BLL.DTO;
using CRM.DAL.Model;
using CRM.Repository;
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

   
        public LegalPersonService(IRepository<LegalPerson> _repository, ContragentService<IndividualPerson> _individualPersonsService) : base((DAL.Interface.IRepository<LegalPerson>)_repository)
        {
            this.individualPersonsService = _individualPersonsService;
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override LegalPerson Get(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<LegalPerson> GetAll()
        {
            try
            {
                if (repository.GetAll() != null && individualPersonsService.GetAll() != null)
                {
                    return (IEnumerable<LegalPerson>)GetLegalPersons.Get_Persons(true,repository,individualPersonsService);
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        public override void Update(LegalPerson item)
        {
            throw new NotImplementedException();
        }
    }
}
