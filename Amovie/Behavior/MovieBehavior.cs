using Amovie.Data;
using Amovie.Models;
using Microsoft.EntityFrameworkCore;

namespace Behaviour
{
    public class MovieBehavior : IMovieBehavior
    {
        private readonly DataContext _context;

        public MovieBehavior(DataContext context)
        {
            _context = context;
        }

        //Get all Movies
        public async Task<List<Movie>> Get()
        {
            return await _context.Movies.ToListAsync();
        }

        //get last Movies
        public async Task<List<Movie>> GetLast()
        {
            var result = _context.Movies.Skip(Math.Max(0, _context.Movies.Count() - 6));
            return await result.ToListAsync();
        }

        //get Movie by id
        public async Task<Movie> GetMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                throw new Exception("Movie not found");
            }
            else
            {
                return movie;
            }
        }

        public async Task<List<Movie>> AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return await _context.Movies.ToListAsync();
        }

        public async Task<List<Movie>> DeleteMovie(int id)
        {
            //var movieId = await _context.Movies.FindAsync(movie.MovieId);

            var movieId = await _context.Movies.FirstOrDefaultAsync(m => m.MovieId == id);

            if (movieId == null)
            {
                throw new Exception("Movie not found");
            }
            else
            {
                _context.Movies.Remove(movieId);
                await _context.SaveChangesAsync();
                return await _context.Movies.ToListAsync();
            }
        }
    }
}
