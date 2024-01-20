

using EF.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Data
{
    public class AppDbContext:DbContext 
    {
        public AppDbContext()
        {


        }
        public AppDbContext(DbContextOptions options):base(options) 
        {
         
            
        }
        public DbSet<Category> categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer("Server=DESKTOP-2848GVF;Database=APiRepositry;Trusted_Connection=True;Integrated Security=true;Encrypt=False;");
            //}
            base.OnConfiguring(optionsBuilder);
        }
   
    }
}
