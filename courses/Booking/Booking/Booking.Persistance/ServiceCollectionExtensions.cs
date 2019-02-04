using Booking.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.Persistance
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<BookingContext>(opt => opt.UseSqlite(connectionString));
            services.AddScoped<IRepository>(provider => provider.GetService<BookingContext>());

            return services;
        }
    }
}
