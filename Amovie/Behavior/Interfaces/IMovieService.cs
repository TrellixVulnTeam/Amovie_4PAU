using Entities.Models.MovieDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behaviour.Interfaces
{
    public interface IMovieService
    {
        Task<List<MoviesDto>> GetAll();
        Task<List<LastMovieDto>> GetLast();
        Task<SingleMovieDto> GetMovie(int id);
        Task AddMovie(AddMovieDto movie);
        Task UpdateMovie(AddMovieDto movie, int id);
        Task DeleteMovie(int id);
        Task<PagedMovieDto> GetPagedMovies(int page, int pageSize);
    }
}
