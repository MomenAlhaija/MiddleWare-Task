
using Microsoft.EntityFrameworkCore;
using ReviewCore3.Model;

namespace ReviewCore3.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {
             
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<ToDoItems> ToDoItems { get; set; } 

    }
}
