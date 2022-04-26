using Amovie.Models;
using Behaviour.Interfaces;
using Entities.Models.MovieDto;
using Microsoft.AspNetCore.Mvc;

namespace Amovie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieBehaviour)
        {
            //_context = context;
            _movieService = movieBehaviour;
        }

        //Get all Movies
        [HttpGet("allmovies")]
        public async Task<ActionResult<List<MoviesDto>>> Get()
        {
            return await _movieService.GetAll();
        }

        //Get last 6 Movies
        [HttpGet("lastmovies")]
        public async Task<ActionResult<List<LastMovieDto>>> GetLast()
        {
            return await _movieService.GetLast();
        }

        //Get Movie by ID
        [HttpGet("{id}")]
        public async Task<ActionResult> GetMovie(int id)
        {
            if(id < 0)
            {
                return BadRequest("Such id does not exist!");
            }
            var movie = await _movieService.GetMovie(id);
            return Ok(movie);
        }

        //Post Movie
        [HttpPost]
        public async Task AddMovie(AddMovieDto movie)
        {
            await _movieService.AddMovie(movie);
        }

        [HttpPut("{id}")]
        public async Task Update(Movie movie, int id)
        {
            await _movieService.UpdateMovie(movie, id);
        }

        //Delete Movie
        [HttpDelete("{id}")]
        public async Task DeleteMovie(int id)
        {
            await _movieService.DeleteMovie(id);
        }

        //GetMovies with page
        [HttpGet("/movies/{page}")]
        public async Task<ActionResult<PagedMovieDto>> GetMovies(int page)
        {
            return await _movieService.GetPagedMovies(page);
        }
    }
}
