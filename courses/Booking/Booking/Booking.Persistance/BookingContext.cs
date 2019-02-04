using System;
using System.Linq;
using System.Threading.Tasks;
using Booking.Domain;
using Microsoft.EntityFrameworkCore;

namespace Booking.Persistance
{
    /*
     * Every DbSet property is marked as internal,because we want to access data 
     * only through interfaces and not from concrete implementations.
     */
    public sealed class BookingContext : DbContext, IRepository
    {
        public BookingContext(DbContextOptions<BookingContext> options)
            : base(options) => Database.Migrate();

        internal DbSet<Customer> Customers { get; private set; }

        internal DbSet<Flight> Flights { get; private set; }

        internal DbSet<FlightBooking> Bookings { get; private set; }

        public IQueryable<TEntity> GetAll<TEntity>()
            where TEntity : Entity => Set<TEntity>().AsNoTracking();

        public async Task<TEntity> FindByIdAsync<TEntity>(Guid id)
            where TEntity : Entity =>
            // here we don't await for the response, we just return the task from SingleOrDefault.
            // and, that task is going to be awaited later where is needed.
            await Set<TEntity>().SingleOrDefaultAsync(e => e.Id == id);

        public async Task AddNewAsync<TEntity>(TEntity entity)
            where TEntity : Entity => await Set<TEntity>().AddAsync(entity);

        public async Task SaveAsync() => await SaveChangesAsync();
    }
}
