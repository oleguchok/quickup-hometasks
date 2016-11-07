using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TestApp.DAL.Model;

namespace TestApp.DAL.Infrastructure
{
    public interface IRepository<T> where T : IEntityBase
    {
        void Add(T entitty);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
    }
}
