using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DAL.Model
{
    public class CRMContext : DbContext
    {
        public DbSet<IndividualPerson> IndividualPersons { get; set; }
        public DbSet<LegalPerson> LegalPersons { get; set; }

        static CRMContext()
        {
            Database.SetInitializer<CRMContext>(new StoreDbInitializer());
        }
        public CRMContext(string connectionString)
            : base(connectionString)
        {
        }
    }

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<CRMContext>
    {
        protected override void Seed(CRMContext db)
        {
            
            db.IndividualPersons.Add(new IndividualPerson(3, "9325152", DateTime.Now.Date, "Человек1", DateTime.Today, null, "Baniyar", "Baniyar", "Baniyar", 2));
            db.IndividualPersons.Add(new IndividualPerson(1, "9325152", DateTime.Now.Date, "Человек1", DateTime.Today, null, "Daniyar", "Daniyar", "Daniyar", 1));
            db.IndividualPersons.Add(new IndividualPerson(2, "9325153", DateTime.Now.Date, "Человек1", DateTime.Today, null, "Amangeldi", "Amangeldi", "Amangeldi",2));
            
            
            
            db.LegalPersons.Add(new LegalPerson(1, "9325152", DateTime.Now.Date, "Человек1", DateTime.Today, null, "TOO Эмиль"));
            db.LegalPersons.Add(new LegalPerson(3, "9325152", DateTime.Now.Date, "Человек1", DateTime.Today, null, "АО КазЦинк"));
            db.LegalPersons.Add(new LegalPerson(2, "9325153", DateTime.Now.Date, "Человек1", DateTime.Today, null, "АО УКТМК"));

            db.SaveChanges();
        }
    }
}
