using Microsoft.EntityFrameworkCore;
using Secondcore.Models;

namespace Secondcore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {
            
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Employee> Employees { get; set; }
    }
}
