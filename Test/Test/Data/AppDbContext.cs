using Microsoft.EntityFrameworkCore;
using Test.Model;

namespace Test.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<ToDoItems> ToDoItems { get; set; }
    }
}
