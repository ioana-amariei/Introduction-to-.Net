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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PointOfInterest>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<PointOfInterest>()
                .Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(150);
        }

    }
}
