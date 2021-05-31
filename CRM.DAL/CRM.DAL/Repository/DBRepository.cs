using CRM.DAL.Interface;
using CRM.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DAL.Repository
{
    public class DBRepository<T> : IRepository<T> where T : class
    {
        private CRMContext _context;
        DbSet<T> _dbSet;

        public DBRepository(string connectionString) 
        {
            _context = new CRMContext(connectionString);
            _dbSet = _context.Set<T>();
        }
        public void Create(IEnumerable<T> item)
        {
            _dbSet.AddRange(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item= _dbSet.Find(id); 
            _dbSet.Remove(item);
            _context.SaveChanges();
        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
