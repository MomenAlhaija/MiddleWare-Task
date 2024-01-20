using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using test2.Models;

namespace test2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

            
        }
        public DbSet<item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        

    }
}
