using Core.Interfaces;
using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly AppDbContext _dbContext;
        private IGenericRepository<T> _entity;
        public UnitOfWork(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public IGenericRepository<T> Entity
        {
            get
            {
                return _entity ?? (_entity = new GenericRepository<T>(_dbContext));
            }
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() > 0;
        }
    }
}
