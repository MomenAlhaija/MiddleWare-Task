using DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public static class AppDbRef
    {
        public static void DbContextRef(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(option => option.UseSqlServer("Server=DESKTOP-2848GVF;Database=MvcRepo;Trusted_Connection=True;Integrated Security=true;Encrypt=False;"));
        }
    }
}
