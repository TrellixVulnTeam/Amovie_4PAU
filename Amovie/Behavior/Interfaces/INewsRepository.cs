using Amovie.Models;

namespace Behaviour.Interfaces
{
    public interface INewsRepository : IRepository<News>
    {
        IEnumerable<News> GetAllMovies();
    }
}
