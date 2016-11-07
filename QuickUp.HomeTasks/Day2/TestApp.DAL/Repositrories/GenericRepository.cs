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

        public GenericRepository(TestAppContext context)
        {
            _context = context;
        }

        public void Add(T entitty)
        {
            _context.Add(entitty);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public T GetById(int id)
        {
            return _context.Set<T>().FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable(); ;
        }
    }
}
