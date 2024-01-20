using Microsoft.EntityFrameworkCore;
using WebApplication6.Data.Model;
using WebApplication6.Model.Model;

namespace WebApplication6.DbComtext
{
    public class AppdbContect:DbContext
    {
        public AppdbContect(DbContextOptions<AppdbContect> options):base(options)
        {
            
        }
        public DbSet<Publisher> publishers { get; set; }
        public  DbSet<Author> Authors { get; set; }
        public  DbSet<Book_author> Book_Authors { get; set; }
        public DbSet<Book> Books { get; set; }  
    }
    
}
