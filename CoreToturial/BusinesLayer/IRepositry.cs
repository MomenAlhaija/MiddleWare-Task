using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer
{
    public interface IRepositry<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        void EditItemAsync(T item,int Id);
        void AddItem(T item);
        void RemoveItemAsync(T item,int Id);   


    }
}
