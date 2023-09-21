namespace Library.DAL.SQL.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        void Remove(T entity);

        void Update(int id, T entity);

        IEnumerable<T> GetAll();

        T Get(int id);
    }
}
