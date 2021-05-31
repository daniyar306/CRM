using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL.DTO
{
    public class LegalPersonDTO : Contragent
    {
        /// <summary>
        /// Полное наименование
        /// </summary>
      
        public string FullName { get; set; }

        /// <summary>
        /// Контактные лица
        /// </summary>
      
        public IEnumerable <IndividualPersonDTO> IndPersons { get; set; }

        public LegalPersonDTO(string Id, string IIN_BIN, DateTime CreateDate, string Create_Autor, DateTime UpdateDate, string Update_Autor, string FullName)
           : base(Id, IIN_BIN, CreateDate, Create_Autor, UpdateDate, Update_Autor)

        {
            this.FullName = FullName;
           

        }

      
    }
}
