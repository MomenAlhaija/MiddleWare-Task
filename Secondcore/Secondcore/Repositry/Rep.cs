using Secondcore.Data;
using Secondcore.Repositry.Base;
namespace Secondcore.Repositry
{

    public class Rep<T> : IRep<T> where T : class
    {
        protected AppDbContext _context;
        public Rep(AppDbContext context)
        {
            this._context = context;
        }
        public T FindById(int id)
        {
            return _context.Set<T>().Find(id);
        }
    }
}
