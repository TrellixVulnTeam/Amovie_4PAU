using Amovie.Data;
using Amovie.Models;
using AutoMapper;
using Behaviour.Interfaces;
using Entities.Models.MovieDto;

namespace Behaviour.Services
{
    public class MovieService : IMovieService
    {

        private readonly IRepository<Movie> _repository;
        private readonly IMapper _mapper;
        public MovieService(IRepository<Movie> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<MoviesDto>> GetAll()
        {
            var movies = _repository.GetAll();

            var moviesDto = _mapper.Map<List<MoviesDto>>(movies);

            return moviesDto;
        }

        public async Task<List<LastMovieDto>> GetLast()
        {
            var lastMovies = _repository.GetAll()
                .Skip(Math
                .Max(0, _repository.GetAll()
                .Count() - 6));

            var moviesDto = _mapper.Map<List<LastMovieDto>>(lastMovies);
            return moviesDto;
        }

        //work...
        public async Task<Movie> GetMovie(int id)
        {
            var movie = _repository.Get(id);

            var movieDto = _mapper.Map<SingleMovieDto>(movie);

            if (movie == null)
            {
                throw new Exception("Movie not found");
            }
            else
            {
                return movie;
            }
        }

        public async Task AddMovie(AddMovieDto movie)
        {
            var moviesDto = _mapper.Map<Movie>(movie);
            _repository.Add(moviesDto);
            _repository.SaveChangesAsync();
        }

        public async Task UpdateMovie(Movie movie, int id)
        {
            var dbMovie = _repository.Get(id);

            if (dbMovie == null)
            {
                throw new Exception("Movie not found");
            }
            else
            {
                dbMovie.Title = movie.Title;
                dbMovie.Image = movie.Image;
                dbMovie.Description = movie.Description;
                dbMovie.Release = movie.Release;
                dbMovie.Rating = movie.Rating;
                dbMovie.Duration = movie.Duration;
                dbMovie.Country = movie.Country;
                dbMovie.Budget = movie.Budget;

                _repository.Update(movie);
                _repository.SaveChangesAsync();
            }
        }

        public async Task DeleteMovie(int id)
        {
            var movieId = _repository.GetAll().FirstOrDefault(m => m.MovieId == id);

            if (movieId == null)
            {
                throw new Exception("Movie not found");
            }
            else
            {
                _repository.Delete(movieId);
                _repository.SaveChangesAsync();
            }
        }

        public async Task<PagedMovieDto> GetPagedMovies(int page)
        {

            var pageResults = 2f;

            var pageCount = Math.Ceiling(_repository.GetAll().Count() / pageResults);

            var movies = _repository.GetAll()
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults);

            var moviesDto = _mapper.Map<List<MoviesDto>>(movies);

            var response = new PagedMovieDto
            {
                Movies = moviesDto,
                CurrentPage = page,
                Pages = (int)pageCount
            };
            return response;

        }
    }
}
