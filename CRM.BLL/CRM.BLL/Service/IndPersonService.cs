using CRM.BLL.DTO;
using CRM.DAL.Interface;
using CRM.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CRM.BLL.Service
{
    class IndPersonService: ContragentService<IndividualPerson>
    {
        public IndPersonService(IRepository<IndividualPerson> _repository) : base((DAL.Interface.IRepository<IndividualPerson>)_repository)
        {

        }

        public override IEnumerable<IndividualPerson> GetAll(bool type)
        {
           try
            {
                if (repository.GetAll() != null)
                    if (type)
                        return repository.GetAll().OrderBy(x => x.LastName).ThenBy(x => x.Name).ThenBy(x => x.SecondName);
                    else
                        return repository.GetAll();
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
