using CRM.Model;
using CRM.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLogicLayer
{
    class LegalPersonController : IPersonController<LegalPerson>
    {
   
        private IPersonController<IndividualPerson> individualPersonsController;

   
        public LegalPersonController(string FileNameCSV, IPersonController<IndividualPerson> individualPersonsController) : base(FileNameCSV)
        {
            this.individualPersonsController = individualPersonsController;
        }

        public override IEnumerable<LegalPerson> Get_Contragents()
        {
            try
            {
                if (repository.Read() != null && individualPersonsController.Get_Contragents()!=null)
                {


                    var result = repository.Read()?.GroupJoin(
                                individualPersonsController.Get_Contragents(),
                                t => t.Id,
                                pl => pl.LegalPerson_Id,
                                (t, pl) => new { t.Id, t.IIN_BIN, t.CreateDate, t.Create_Autor, t.UpdateDate, t.Update_Autor, t.FullName, pl }

                                );
                    //Баг CSVHelper.... Ломается при создании в классе своиства с типом IEnumerable и инициализации его через конструктор
                    List<LegalPerson> LegalPersons = new List<LegalPerson>();
                    foreach (var item in result)
                    {
                        LegalPerson legalPerson = new LegalPerson(item.Id, item.IIN_BIN, (DateTime)item.CreateDate, item.Create_Autor, (DateTime)item.UpdateDate, item.Update_Autor, item.FullName);
                        legalPerson.IndPersons = item.pl;


                        LegalPersons.Add(legalPerson);
                    }


                    return LegalPersons.OrderByDescending(x => x.IndPersons.Count());
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
