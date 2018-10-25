using Microsoft.EntityFrameworkCore;

namespace IntroEFCore
{
    public sealed class TodoContext : DbContext
    {
        public TodoContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Todo> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=Todos;Trusted_Connection=True;");
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>()
                .Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(40);
        }
    }
}
