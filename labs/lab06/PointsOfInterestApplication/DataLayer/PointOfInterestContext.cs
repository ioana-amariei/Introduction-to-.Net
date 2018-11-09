using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public sealed class PointOfInterestContext : DbContext
    {
        private const string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=PoisManagement;Trusted_Connection=True;";
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
                .Property(poi => poi.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<PointOfInterest>()
                .Property(poi => poi.Description)
                .IsRequired()
                .HasMaxLength(150);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                ConnectionString);
        }
    }
}
