using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CRM.BLL.Service;
using CRM.BLL.DTO;

namespace CRM
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region IndividualPerson
               
                Console.WriteLine("Вывод физ. лиц\n");

                IndPersonService IndividualPersonsService = new IndPersonService("Individual.csv");
                     List<IndividualPerson> IndividualPersons = new List<IndividualPerson>()
                 {
                   new IndividualPerson(3, "9325152", DateTime.Now.Date, "Человек1", DateTime.Today, null, "Baniyar", "Baniyar", "Baniyar", 2)
                  ,new IndividualPerson(1, "9325152", DateTime.Now.Date, "Человек1", DateTime.Today, null, "Daniyar", "Daniyar", "Daniyar", 1)
                  ,new IndividualPerson(2, "9325153", DateTime.Now.Date, "Человек1", DateTime.Today, null, "Amangeldi", "Amangeldi", "Amangeldi", 2)

                 };

                IndividualPersonsService.Create(IndividualPersons);

                if (IndividualPersonsService.GetAll(true) != null)
                {
                    foreach (var t in IndividualPersonsService.GetAll(true))
                        Console.WriteLine($"Имя:{t.Name}, Фамилия: {t.LastName}, Отчество: {t.SecondName}");
                }

                #endregion

                #region LegalPerson

                Console.WriteLine("Вывод юр. лиц\n");

                List<LegalPerson> LegalPersons = new List<LegalPerson>()
            {
             new LegalPerson(1, "9325152", DateTime.Now.Date, "Человек1", DateTime.Today, null, "TOO Эмиль")
            ,new LegalPerson(2, "9325152", DateTime.Now.Date, "Человек1", DateTime.Today, null, "АО КазЦинк")
            ,new LegalPerson(3, "9325153", DateTime.Now.Date, "Человек1", DateTime.Today, null, "АО УКТМК")
            };


                LegalPersonService LegalPersonsService = new LegalPersonService("Legal.csv", IndividualPersonsService);

                LegalPersonsService.Create(LegalPersons);

                if (LegalPersonsService.GetAll(true) != null)
                {
                    foreach (var t in LegalPersonsService.GetAll(true))
                    {
                        Console.Write($"Наименование юр. лицо:{t.FullName} , количество конт.лиц: {t.IndPersons.Count()}, контактное лицо:");
                        foreach (var persons in t.IndPersons)
                            Console.WriteLine($" Имя:{persons.Name}  Фамилия:{persons.LastName} ");
                    }

                }
                #endregion
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();


        }
    }
}
