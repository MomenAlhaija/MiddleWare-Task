using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext()
        {
            
        }
        public AppDbContext(DbContextOptions options):base(options) 
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-2848GVF;Database=MvcRepo;Trusted_Connection=True;Integrated Security=true;Encrypt=False;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Autho> Authos { get;set; } 
        public DbSet<Book> Books { get;set; }
    }
}
