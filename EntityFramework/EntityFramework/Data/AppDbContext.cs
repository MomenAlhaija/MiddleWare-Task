using EntityFramework.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Data
{
    internal class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseSqlServer("Server=DESKTOP-2848GVF;Database=EFAdvanc;Trusted_Connection=True;Integrated Security=true;Encrypt=False;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Employee>().Property(E=>E.name).IsRequired();
            modelBuilder.Entity<Employee>()
    .HasOne(e => e.Department)
    .WithMany(d => d.Employees)
    .HasForeignKey(e => e.DepId);
        }
        public DbSet<Employee> Employees { get; set; } 
        public DbSet<Dep> Departments { get; set; }
    }
}
