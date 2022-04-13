using Amovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behaviour
{
    public interface IMovieBehavior
    {
        public Task<List<Movie>> Get();
        public Task<List<Movie>> GetLast();
        public Task<Movie> GetMovie(int id);
        public Task<List<Movie>> AddMovie(Movie movie);
        public Task<List<Movie>> DeleteMovie(int id);

    }
}
