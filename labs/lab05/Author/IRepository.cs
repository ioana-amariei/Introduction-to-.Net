using System;
using System.Linq;

namespace Authors
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Entities { get; }
        void Create(T entity);
        void RemoveById(Guid id);
    }
}