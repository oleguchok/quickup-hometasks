using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QuickOrder.DAL.Infrastructure;
using QuickOrder.Entities;

namespace QuickOrder.DAL.Repostitories
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T: class, IEntityBase
    {
        private readonly QuickOrderContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public EntityBaseRepository(QuickOrderContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public T GetById(int id)
        {
            return _dbSet.AsNoTracking().FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }
    }
}
