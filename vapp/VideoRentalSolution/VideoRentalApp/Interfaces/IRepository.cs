namespace VideoRentalApp.Interfaces
{
    public interface IRepository<K, T>
    {
        /// <summary>
        /// This is Common interface
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        T GetById(K key);
        IList<T> GetAll();
        T Add(T entity);
        T Update(T entity);
        T Delete(K key);
    }
}