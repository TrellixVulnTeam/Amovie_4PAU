

namespace Behaviour.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        T Get<TEntity>(TEntity id);
        IQueryable<T> GetAll();
        void Update(T entity);
        void Delete(T id);

        void SaveChangesAsync();
    }
}
