using ExampleEFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleEFCore.data
{
    public class MyAppDbContext:DbContext
    {
        public MyAppDbContext(DbContextOptions<MyAppDbContext>  options):base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set;}
        public DbSet<Department> Departments { get; set;}
        public DbSet<Information> Informations { get; set;}
    }
   
}
