using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model
{
    public class IndividualPerson:Contragent 
    {
        [Name("Name")]
        public string Name { get; set; }

        [Name("SecondName")]
        public string SecondName { get; set; }

        [Name("LastName")]
        public string LastName { get; set; }

        [Name("LegalPerson_Id")]
        public string LegalPerson_Id { get; set; }

        public IndividualPerson(string Id, string IIN_BIN, DateTime CreateDate, string Create_Autor, DateTime UpdateDate, string Update_Autor,string Name, string SecondName,string LastName, string LegalPerson_Id)
            : base(Id,IIN_BIN, CreateDate, Create_Autor, UpdateDate, Update_Autor) 

        {
            this.Name = Name;

            this.SecondName = SecondName;

            this.LastName = LastName;

            this.LegalPerson_Id = LegalPerson_Id;
        }

    }
}
