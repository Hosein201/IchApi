using Entities.Configuration;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Entities
{
    public class AppDbContext : DbContext
    {
        //public AppDbContext()
        //    : base(""){ }
            
        public AppDbContext(DbContextOptions options) :
            base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // DbSetConfiguration(builder);
            FluentApi(builder);
        }

        private void DbSetConfiguration(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CompanyConfiguration());
            builder.ApplyConfiguration(new EmployeeConfiguration());
        }

        private void FluentApi(ModelBuilder builder)
        {
            //Company
            builder.Entity<Company>()
                .HasKey(h => h.Id);

            builder.Entity<Company>()
                .HasMany<Employee>(h => h.Employees)
                .WithOne(w => w.Company)
                .HasForeignKey(f => f.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Company>()
                .HasData(SeedCompany);

            //Employee
            builder.Entity<Employee>()
               .HasKey(h => h.Id);

            builder.Entity<Employee>()
               .HasData(SeedEmployee);
        }

        private List<Employee> SeedEmployee => new();

        private List<Company> SeedCompany => new();
    }
}
