using Microsoft.EntityFrameworkCore;
using OrderingDomain.Models;
using System;
using System.Reflection;


namespace OrderingInfrastructure.Data
{
    public class ApplicationDbContext : DbContext   
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
        
        }

        public DbSet<Customer> Customers  => Set<Customer>();

        public DbSet<Product> Products => Set<Product>();

        public DbSet<Order> Orders => Set<Order>();

        public DbSet<OrderItem> OrderItems => Set<OrderItem>();

        protected override void OnModelCreating(ModelBuilder builder)
        {

            //builder.Entity<Customer>().Property(c => c.Name).IsRequired().HasMaxLength(100);
            // Scan all class has implemented IEntityTypeConfiguration interface -> help us to seperate configuration to smaller class, instead of do all it here. 
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

    }
}
