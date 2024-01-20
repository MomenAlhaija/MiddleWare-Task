
using Microsoft.EntityFrameworkCore;
using ReviewTheCore.Model;

namespace ReviewTheCore.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Person> Persons { get; set; }


    }
}
