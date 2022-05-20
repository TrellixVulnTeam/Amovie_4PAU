using Behaviour.Interfaces;
using Entities.Models.MovieDto;
using Microsoft.AspNetCore.Mvc;

namespace Amovie.Controllers
{
    [Route("api/movies/")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        //Get all Movies
        [HttpGet("allmovies")]
        public async Task<ActionResult<List<MoviesDto>>> Get()
        {
            try
            {
                var result = await _movieService.GetAll();
                if(result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }

            catch (Exception)
            {
                return BadRequest();
            }
        }

        //Get last 6 Movies
        [HttpGet("lastmovies")]
        public async Task<ActionResult<List<LastMovieDto>>> GetLast()
        {
            var movieList = await _movieService.GetLast();
            return Ok(movieList);
        }

        //Get Movie by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<SingleMovieDto>> GetMovie(int id)
        {
            try
            {
                var result = await _movieService.GetMovie(id);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //Add Movie
        [HttpPost("/create")]
        public async Task<ActionResult> AddMovieWithGenre(AddMovieDto movieDto)
        {
            await _movieService.AddMovie(movieDto);
            return Ok();
        }

        //Update Movie
        [HttpPut("{id}")]
        public async Task Update(AddMovieDto movieDto, int id)
        {
            await _movieService.UpdateMovie(movieDto, id);
        }

        //Delete Movie
        [HttpDelete("{id}")]
        public async Task DeleteMovie(int id)
        {
            await _movieService.DeleteMovie(id);
        }

        //GetMovies with page
        [HttpGet("/pagedmovies/{page}")]
        public async Task<ActionResult<PagedMovieDto>> GetMovies(int page = 1, int pageSize = 2)
        {
            var pagedMovies = await _movieService.GetPagedMovies(page, pageSize);

            return Ok(pagedMovies);
        }

        //Filter movies by title
        [HttpGet("/movies/filter")]
        public async Task<ActionResult<MoviesDto>> GetFilterMovies(string title)
        {
            var filterMovies = await _movieService.FilterMovies(title);
            return Ok(filterMovies);
        }

        //Sort movies by rating
        [HttpGet("/movies/sort")]
        public async Task<ActionResult<MoviesDto>> GetSortedMovies(string sort)
        {
            var sortedMovies = await _movieService.SortMovies(sort);
            return Ok(sortedMovies);
        }
    }
}
