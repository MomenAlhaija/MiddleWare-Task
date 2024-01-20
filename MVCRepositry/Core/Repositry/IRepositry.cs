
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositry
{
    public interface IRepositry<T> where T : class
    {
       Task<T> GetAsync(int id);
       Task<IEnumerable<T>> GetAllAsync();
       Task<IEnumerable<T>> GetAllWithEntityAsync(params string[] args);
        T FindBy(Expression<Func<T, bool>> match);
        T FindBy(Expression<Func<T, bool>> match,params string[] args);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> match, params string[] args);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> match,int skip,int take);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> match, int skip, int take,params string[] args);

        IEnumerable<T> FindAll(Expression<Func<T, bool>> match, int skip, int take, Expression<Func<T, object>> orderBy, string  direction="ASC",params string[] args);

        T Add(T item);

       IEnumerable<T> AddRange(IEnumerable<T> items);


    }
}
