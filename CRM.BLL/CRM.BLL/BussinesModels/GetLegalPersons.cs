using CRM.BLL.DTO;
using CRM.BLL.Service;
using CRM.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL.BussinesModels
{
    public class GetLegalPersons
    {
        /// <summary>
        /// Сделать вывод 5 записей из списка юр. лиц. Упорядочить список юр. лиц  по количеству контактных лиц (по убыванию).  
        /// </summary>
        /// <param name="type">true- выполняется согласно логике</param>
        /// <param name="repository">объект IRepository<IndividualPersonDTO></param>
        /// <param name="individualPersonsService">объект ContragentService<IndividualPersonDTO></param>
        /// <returns></returns>
        public static IEnumerable <LegalPerson> Get_Persons(bool type, IRepository<LegalPerson> repository, ContragentService<IndividualPerson> individualPersonsService)
        {
            if(type)
            {
                var result = repository.GetAll()?.GroupJoin(
                                           individualPersonsService.GetAll(type),
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
            {
                return (IEnumerable<LegalPerson>)repository.GetAll();

            }

        }


    }
}
