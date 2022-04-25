using Amovie.Data;
using Behaviour.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Behaviour.Abstract
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly DataContext _context;
        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public T Get<TEntity>(TEntity id)
        {
            return _context.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(T id)
        {
            _context.Set<T>().Remove(id);
        }

        public void SaveChangesAsync()
        {
            _context.SaveChangesAsync();
        }


    }
}
