using CRM.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Model;

namespace CRM.BLogicLayer
{
    class IndPersonController: IPersonController<IndividualPerson>
    {
        public IndPersonController(string FileName) : base(FileName)
        {

        }

    
        public override IEnumerable <IndividualPerson> Get_Contragents() 
        {
            try
            {
                if (repository.Read()!=null)
                    return repository.Read().OrderBy(x => x.LastName).ThenBy(x => x.Name).ThenBy(x => x.SecondName);
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
