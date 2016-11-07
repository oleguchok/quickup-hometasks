using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestApp.DAL.Infrastructure;
using TestApp.DAL.Model;

namespace TestApp.DAL.Repositrories
{
    public class GenericRepository<T> : IRepository<T>
        where T : class, IEntityBase
    {
        private TestAppContext _context;
        private DbSet<T> _dbSet;

        public GenericRepository(TestAppContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entitty)
        {
            _context.Add(entitty);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public T GetById(int id)
        {
            return _dbSet.AsNoTracking().FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable(); ;
        }
    }
}
