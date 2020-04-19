using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext;
        private DbSet<T> table = null;
        public GenericRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
            table = _dbContext.Set<T>();
        }
        public void Add(T entity)
        {
            table.Add(entity);
        }

        public void Delete(object id)
        {
            var entity = GetById(id);
            table.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Update(T entity)
        {
            table.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
