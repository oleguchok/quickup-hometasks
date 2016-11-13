using System.Collections.Generic;
using QuickOrder.Entities;

namespace QuickOrder.DAL.Infrastructure
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
