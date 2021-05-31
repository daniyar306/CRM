using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL.DTO
{
    public class IndividualPersonDTO:Contragent 
    {
      
        public string Name { get; set; }

       
        public string SecondName { get; set; }

    
        public string LastName { get; set; }

      
        public string LegalPerson_Id { get; set; }

        public IndividualPersonDTO(string Id, string IIN_BIN, DateTime CreateDate, string Create_Autor, DateTime UpdateDate, string Update_Autor,string Name, string SecondName,string LastName, string LegalPerson_Id)
            : base(Id,IIN_BIN, CreateDate, Create_Autor, UpdateDate, Update_Autor) 

        {
            this.Name = Name;

            this.SecondName = SecondName;

            this.LastName = LastName;

            this.LegalPerson_Id = LegalPerson_Id;
        }

    }
}
