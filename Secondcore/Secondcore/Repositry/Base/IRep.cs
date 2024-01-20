namespace Secondcore.Repositry.Base
{
    public interface IRep<T> where T : class
    {
        T FindById(int id);
    }
}
