using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public sealed class PointOfInterestContext : DbContext
    {
        public DbSet<PointOfInterest> PointOfInterests { get; set; }

        public PointOfInterestContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public PointOfInterestContext()
        {
        }
        
    }
}
