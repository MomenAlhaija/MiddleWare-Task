using DAL.AppDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public static class AppDbRef
    {
        public static void RegisterDbInfrastrucre(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer("Server=DESKTOP-2848GVF;Database=NewAPI;Trusted_Connection=True;Integrated Security=true;Encrypt=False;"));
        }
    }
}
