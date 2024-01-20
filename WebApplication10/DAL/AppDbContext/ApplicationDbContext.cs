
using DAL.Model;
using Microsoft.EntityFrameworkCore;
namespace DAL.AppDbContext
{
    public class ApplicationDbContext :DbContext
    {
        public  ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-2848GVF;Database=NewAPI;Trusted_Connection=True;Integrated Security=true;Encrypt=False;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Autho> Authos { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
