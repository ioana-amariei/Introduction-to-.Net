using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public sealed class CityContext : DbContext
    {
        private const string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=CityManagement;Trusted_Connection=True;";
        public DbSet<City> Cities { get; set; }
        public DbSet<PointOfInterest> PointOfInterests { get; set; }

        public CityContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public CityContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<City>()
                .Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(150);

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