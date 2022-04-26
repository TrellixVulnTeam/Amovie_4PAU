using Amovie.Models;
using Entities.Models.MovieDto;

namespace Behaviour.Interfaces
{
    public interface IMovieService
    {
         Task<List<MoviesDto>> GetAll();
         Task<List<LastMovieDto>> GetLast();
         Task<Movie> GetMovie(int id);
         Task AddMovie(AddMovieDto movie);
         Task UpdateMovie(Movie movie, int id);
         Task DeleteMovie(int id);
         Task<PagedMovieDto> GetPagedMovies(int page);
    }
}
