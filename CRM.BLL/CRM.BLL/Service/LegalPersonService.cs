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


        public override IEnumerable<LegalPerson> GetAll(bool type)
        {
            try
            {
                if (repository.GetAll() != null && individualPersonsService.GetAll(type) != null)
                {
                    return GetLegalPersons.Get_Persons(type, repository,individualPersonsService);
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

    }
}
