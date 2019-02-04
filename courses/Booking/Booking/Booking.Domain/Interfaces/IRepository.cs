using System;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Domain
{
    public interface IRepository
    {
        IQueryable<TEntity> GetAll<TEntity>()
            where TEntity : Entity;

        Task<TEntity> FindByIdAsync<TEntity>(Guid id)
            where TEntity : Entity;

        Task AddNewAsync<TEntity>(TEntity entity)
            where TEntity : Entity;

        Task SaveAsync();
    }
}
