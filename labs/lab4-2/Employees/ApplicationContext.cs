﻿using Microsoft.EntityFrameworkCore;

namespace Employees
{
    public sealed class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Employee> Employees { get; }
        public DbSet<Customer> Customers { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Property(c => c.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Customer>().Property(c => c.Address).IsRequired().HasMaxLength(300);
            
            var customerValidator = new CustomerValidator(); //????
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mslocaldb;Database=Products;Trusted_Connection=True;");
        }
    }
}