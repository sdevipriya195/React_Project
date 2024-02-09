namespace Bookstore.Interfaces
{
    public interface IRepository<K,T>
    {
        T GetById(K Key);
        IList<T> GetAll();
        T Add(T entity);
        T Update(T entity);
        T Delete(K Key);
    }
}
