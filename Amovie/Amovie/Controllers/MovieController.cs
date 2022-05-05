using AutoMapper;
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
            return Ok (await _movieService.GetAll());
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
        public async Task<SingleMovieDto> GetMovie(int id)
        {
            return await _movieService.GetMovie(id);
        }

        [HttpPost("/create")]
        public async Task<ActionResult> AddMovieWithGenre(AddMovieDto movieDto)
        {
            await _movieService.AddMovie(movieDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task Update(AddMovieDto movieDto, int id)
        {
            await _movieService.UpdateMovie(movieDto, id);
        }

        ////Delete Movie
        [HttpDelete("{id}")]
        public async Task DeleteMovie(int id)
        {
            await _movieService.DeleteMovie(id);
        }

        //GetMovies with page
        [HttpGet("/movies/paged")]
        public async Task<ActionResult<PagedMovieDto>> GetMovies(int page = 1, int pageSize = 2)
        {
            var pagedMovies = await _movieService.GetPagedMovies(page, pageSize);

            return Ok(pagedMovies);
        }
    }
}
