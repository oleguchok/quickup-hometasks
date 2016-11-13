namespace QuickOrder.DAL.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QuickOrderContext _dbContext;

        public UnitOfWork(QuickOrderContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
