using System;
using System.Linq;

namespace Authors
{
    public class GenericRepository<T> : IRepository<T> where T:class 
    {
        private readonly ApplicationContext _dbContext;

        private Microsoft.EntityFrameworkCore.DbSet<T> DbSet => _dbContext.Set<T>();
        public IQueryable<T> Entities => DbSet;

        public GenericRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(T entity)
        {
            DbSet.Add(entity);
        }

        public void RemoveById(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }
    }
}
