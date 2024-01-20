using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositries
{
    public interface IRepositry<T> where T : class
    {
        T GetByID(int id);
        Task<T> GetByIdAsync(int id); 

        IEnumerable<T> GetAll();
    }

}
