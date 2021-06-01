using CRM.BLL.BussinesModels;
using CRM.BLL.DTO;
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

   
        public LegalPersonService(string constring, ContragentService<IndividualPerson> _individualPersonsService) : base(constring)
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
