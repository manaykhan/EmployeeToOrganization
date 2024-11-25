using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using CrudAPI.Models;

namespace CrudAPI.AppDataContext
{

    // EmployeeDbContext class inherits from DbContext
     public class EmployeeDbContext : DbContext
     {

        // DbSettings field to store the connection string
         private readonly DbSettings _dbsettings;

            // Constructor to inject the DbSettings model
         public EmployeeDbContext(IOptions<DbSettings> dbSettings)
         {
             _dbsettings = dbSettings.Value;
         }


        // DbSet property to represent the emp table
         public DbSet<Employee> Employees { get; set; } = null!;

         // Configuring the database provider and connection string

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             optionsBuilder.UseSqlServer(_dbsettings.ConnectionString);
         }

            // Configuring the model for the emp entity
         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             modelBuilder.Entity<Employee>()
                 .ToTable("Employees")
                 .HasKey(x => x.Id);
         }
     }
}