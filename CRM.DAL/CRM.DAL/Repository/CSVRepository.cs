using CRM.DAL.Interface;
using CRM.DAL.Model;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DAL.Repository
{
    public class CSVRepository<T> : IRepository<T> where T : class
    {

        protected string LocalPath;

        private string GetAppPath()
        {
            string codeBase = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            return System.IO.Path.GetDirectoryName(codeBase);
        }

        public CSVRepository(string filename)
        {
            var _path = System.IO.Path.Combine(GetAppPath(), filename);
            LocalPath = new Uri(_path).LocalPath;
        }

        public IEnumerable<T> GetAll()
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public T Get(int id)
        {
            return GetAll().FirstOrDefault(x=>x.Equals(id));
        }

        public void Create(IEnumerable<T> item)
        {
            using (var writer = new StreamWriter(LocalPath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                if (item != null)
                    csv.WriteRecords(item);
            }
        }

        public void Create(T item)
        {
            using (var writer = new StreamWriter(LocalPath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                if (item != null)
                    csv.WriteRecord(item);
            }
        }

        public void Update(T item)
        {
            Delete(item);
            Create(item);

        }

        public void Delete(T item)
        {
            List<T> items = (List<T>)GetAll();
            bool isremoved = items.Remove(item);
            if (isremoved)
            {
                using (var writer = new StreamWriter(LocalPath))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    if (items != null)
                        csv.WriteRecords(items);
                }
            }
          

        }

    }
}
