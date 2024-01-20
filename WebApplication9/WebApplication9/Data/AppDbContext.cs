
using Microsoft.EntityFrameworkCore;
using WebApplication9.Models;

namespace WebApplication9.Data
{
    public class AppDbContext:DbContext
    {


        public AppDbContext(DbContextOptions options):base(options) 
        {
                
        }

        public DbSet<Person> Persons { get; set; }

    }
}
