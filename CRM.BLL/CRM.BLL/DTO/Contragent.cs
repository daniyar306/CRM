using CsvHelper.Configuration.Attributes;
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
        [Name("Id")]
        public int Id { get; set; }
        /// <summary>
        /// ИИН/БИН
        /// </summary>
        [Name("IIN_BIN")]
        public string IIN_BIN { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        [Name("CreateDate")]
        public DateTime? CreateDate{ get; set; }
        /// <summary>
        /// Автор создания
        /// </summary>
        [Name("Create_Autor")]
        public string Create_Autor{ get; set; }
        /// <summary>
        /// Дата изменения
        /// </summary>
        [Name("UpdateDate")]
        public DateTime?  UpdateDate{ get; set; }
        /// <summary>
        /// Автор изменения
        /// </summary>
        [Name("Update_Autor")]
        public string Update_Autor{ get; set; }

       public Contragent(int Id,string IIN_BIN,DateTime CreateDate,string Create_Autor,DateTime UpdateDate,string Update_Autor) 
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
