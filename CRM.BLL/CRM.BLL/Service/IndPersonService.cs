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
    class IndPersonService: ContragentService<IndividualPerson>
    {
        public IndPersonService(IRepository<IndividualPerson> _repository) : base((DAL.Interface.IRepository<IndividualPerson>)_repository)
        {

        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override IndividualPerson Get(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<IndividualPerson> GetAll()
        {
           try
            {
                if (repository.GetAll() != null)
                    return repository.GetAll().OrderBy(x => x.LastName).ThenBy(x => x.Name).ThenBy(x => x.SecondName);
                else
                    return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public override void Update(IndividualPerson item)
        {
            throw new NotImplementedException();
        }
    }
}
