using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL.DTO
{
    public abstract  class Contragent
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
    
        public string Id { get; set; }
        /// <summary>
        /// ИИН/БИН
        /// </summary>
      
        public string IIN_BIN { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
     
        public DateTime? CreateDate{ get; set; }
        /// <summary>
        /// Автор создания
        /// </summary>
      
        public string Create_Autor{ get; set; }
        /// <summary>
        /// Дата изменения
        /// </summary>
     
        public DateTime?  UpdateDate{ get; set; }
        /// <summary>
        /// Автор изменения
        /// </summary>
     
        public string Update_Autor{ get; set; }

       public Contragent(string Id,string IIN_BIN,DateTime CreateDate,string Create_Autor,DateTime UpdateDate,string Update_Autor) 
        {
            this.Id = Id;

            this.IIN_BIN = IIN_BIN;

            this.CreateDate = CreateDate;

            this.Create_Autor = Create_Autor;

            this.UpdateDate = UpdateDate;

            this.Update_Autor = Update_Autor;
        }
    }
}
