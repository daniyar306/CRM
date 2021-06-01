using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DAL.Model
{
    public class LegalPerson : Contragent
    {
        /// <summary>
        /// Полное наименование
        /// </summary>
        [Name("FullName")]
        public string FullName { get; set; }

        /// <summary>
        /// Контактные лица
        /// </summary>
        [Optional]
        public IEnumerable <IndividualPerson> IndPersons { get; set; }

        public LegalPerson(int Id, string IIN_BIN, DateTime CreateDate, string Create_Autor, DateTime UpdateDate, string Update_Autor, string FullName)
           : base(Id, IIN_BIN, CreateDate, Create_Autor, UpdateDate, Update_Autor)

        {
            this.FullName = FullName;
           

        }

      
    }
}
