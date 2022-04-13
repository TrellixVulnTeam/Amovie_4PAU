using Amovie.Data;
using Amovie.Models;
using Behaviour;
using Microsoft.AspNetCore.Mvc;

namespace Amovie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMovieBehavior _movieBehaviour;

        public MovieController(DataContext context, IMovieBehavior movieBehaviour)
        {
            _context = context;
            _movieBehaviour = movieBehaviour;
        }

        //Get all Movies
        [HttpGet("allmovies")]
        public async Task<ActionResult<List<Movie>>> Get()
        {
            return await _movieBehaviour.Get();
        }

        //Get last 6 Movies
        [HttpGet("lastmovies")]
        public async Task<ActionResult<List<Movie>>> GetLast()
        {
            return await _movieBehaviour.GetLast();
        }

        //Get Movie by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            return await _movieBehaviour.GetMovie(id);
        }

        //Post Movie
        [HttpPost]
        public async Task<ActionResult<List<Movie>>> AddMovie(Movie movie)
        {

            return await _movieBehaviour.AddMovie(movie);
        }

        //Delete Movie
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Movie>>> DeleteMovie(int id)
        {
            return await _movieBehaviour.DeleteMovie(id);
        }
    }
}
