using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.BLogicLayer;
using CRM.Model;
using CRM.Repository;
using CsvHelper;

namespace CRM
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Вывод физ. лиц\n");
            IPersonController<IndividualPerson> IndividualPersonsController = new IndPersonController("Individual.csv");
            List<IndividualPerson> IndividualPersons = new List<IndividualPerson>()
            {
              new IndividualPerson("3", "9325152", DateTime.Now.Date, "Человек1", DateTime.Today, null, "Baniyar", "Baniyar", "Baniyar", "2")
             ,new IndividualPerson("1", "9325152", DateTime.Now.Date, "Человек1", DateTime.Today, null, "Daniyar", "Daniyar", "Daniyar", "1")
             ,new IndividualPerson("2", "9325153", DateTime.Now.Date, "Человек1", DateTime.Today, null, "Amangeldi", "Amangeldi", "Amangeldi", "2")

            };

            IndividualPersonsController.Set_Contragents(IndividualPersons);

          
             foreach (var t in IndividualPersonsController.Get_Contragents())
                  Console.WriteLine($"Имя:{t.Name}, Фамилия: {t.LastName}, Отчество: {t.SecondName}");

            Console.WriteLine("Вывод юр. лиц\n");

            List<LegalPerson> LegalPersons = new List<LegalPerson>()
            {
             new LegalPerson("1", "9325152", DateTime.Now.Date, "Человек1", DateTime.Today, null, "TOO Эмиль")
            ,new LegalPerson("3", "9325152", DateTime.Now.Date, "Человек1", DateTime.Today, null, "АО КазЦинк")
            ,new LegalPerson("2", "9325153", DateTime.Now.Date, "Человек1", DateTime.Today, null, "АО УКТМК")
            };


            IPersonController<LegalPerson> LegalPersonsController = new LegalPersonController("Legal.csv", IndividualPersonsController);
            LegalPersonsController.Set_Contragents(LegalPersons);

            foreach (var t in LegalPersonsController.Get_Contragents()) 
            {
               Console.Write($"Наименование юр. лицо:{t.FullName} , количество конт.лиц: {t.IndPersons .Count()}---");
                 foreach (var persons in t.IndPersons)
                  Console.WriteLine($"контактное лицо, Имя:{persons.Name}  Фамилия:{persons.LastName} ");
            
            }

            Console.ReadKey();


        }
    }
}
