using System;
using System.Linq;

namespace Employees
{
    public interface IRepository<T>
    {
        void Create(T item);
        void Update(T item);
        void Delete(T item);
        T GetById(Guid id);
        IQueryable<T> GetAll();
    }
}
