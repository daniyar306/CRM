using CRM.Model;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected string LocalPath;

        private string GetAppPath()
        {
            string codeBase = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            return System.IO.Path.GetDirectoryName(codeBase);
        }

        public Repository(string filename)
        {
            var _path = System.IO.Path.Combine(GetAppPath(), filename);
            LocalPath = new Uri(_path).LocalPath;
        }

        public IEnumerable<T> Read() 
        {
            try
            {
                using (var reader = new StreamReader(LocalPath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    //Баг CSVHelper.... Ломается при создании в классе своиства с типом IEnumerable и инициализации его через конструктор

                    return csv.GetRecords<T>().ToList();

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
         

        }

        public void Write(IEnumerable<T> records) 
        {
            using (var writer = new StreamWriter(LocalPath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                if(records !=null)
                csv.WriteRecords(records);
            }

        }

      
    }
}
