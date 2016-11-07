using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.DAL.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TestAppContext _dbContext;

        public UnitOfWork(TestAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
