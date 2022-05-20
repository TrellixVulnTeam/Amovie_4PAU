using AutoMapper;
using Behaviour.Interfaces;
using DataAccess.Data;
using Entities.Entities;
using Entities.Models.MovieDto;
using Microsoft.EntityFrameworkCore;

namespace Behaviour.Services
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _repository;
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public MovieService(IRepository<Movie> repository, IMapper mapper, DataContext context)
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;
        }
        public async Task<List<MoviesDto>> GetAll()
        {
            var movies = await _repository.GetAll();

            var moviesDto = _mapper.Map<List<MoviesDto>>(movies);

            return moviesDto;
        }

        public async Task<List<LastMovieDto>> GetLast()
        {
            var allMovies = await _repository.GetAll();
            var lastMovies = allMovies
            .Skip(Math
            .Max(0, allMovies
            .Count() - 6));

            var moviesDto = _mapper.Map<List<LastMovieDto>>(lastMovies);
            return moviesDto;
        }

        //Get Movie by id
        public async Task<SingleMovieDto> GetMovie(int id)
        {
            var movie = await _repository.GetByIdWithIncludes(id, x => x.Genres, x => x.Actors, x => x.Reviews);

            var movieDto = _mapper.Map<SingleMovieDto>(movie);

            if (movie == null)
            {
                throw new Exception("Movie not found");
            }
            else
            {
                return movieDto;
            }
        }
       //Add Movie
        public async Task AddMovie(AddMovieDto movieDto)
        {
            var genres = await _context.Genres.Where(x => movieDto.GenreId.Contains(x.Id)).ToListAsync();
            var actors = await _context.Actors.Where(x => movieDto.ActorId.Contains(x.Id)).ToListAsync();

            var movie = _mapper.Map<Movie>(movieDto);
            movie.Genres = genres;
            movie.Actors = actors;

            await _repository.Add(movie);
            await _repository.SaveChangesAsync();
        }

        //Update Movie
        public async Task UpdateMovie(AddMovieDto movieDto, int id)
        {
            var genres = await _context.Genres.Where(x => movieDto.GenreId.Contains(x.Id)).ToListAsync();
            var actors = await _context.Actors.Where(x => movieDto.ActorId.Contains(x.Id)).ToListAsync();

            var movie = await _repository.Get(id);
            
            movie = _mapper.Map<Movie>(movieDto);
            movie.Genres = genres;
            movie.Actors = actors;

            await _repository.Update(movie);
            await _repository.SaveChangesAsync();
        }

        //Delete Movie
        public async Task DeleteMovie(int id)
        {
            var allMovies = await _repository.GetAll();

            var movie = allMovies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
            {
                throw new Exception("Movie not found");
            }
            else
            {
                await _repository.Delete(movie.Id);
                await _repository.SaveChangesAsync();
            }
        }

        //Get paged Movie
        public async Task<PagedMovieDto> GetPagedMovies(int page, int pageSize)
        {
            var allMovies = await _repository.GetAll();
            var pageCount = Math.Ceiling(allMovies.Count() / (float)pageSize);

            var movies = allMovies.AsQueryable()
                .Skip((page - 1) * (int)pageSize)
                .Take((int)pageSize);

            var moviesDto = _mapper.Map<List<MoviesDto>>(movies);

            var response = new PagedMovieDto
            {
                Movies = moviesDto,
                CurrentPage = page,
                Pages = (int)pageCount
            };
            return response;
        }
            
        //Filter movie
        public async Task<List<MoviesDto>> FilterMovies(string title)
        {
            var allMovies = await _repository.GetAll();
            var filterMovies = allMovies.Where(x => x.Title.ToLower().Contains(title.ToLower()));

            var filterMoviesDto = _mapper.Map<List<MoviesDto>>(filterMovies);
            return filterMoviesDto;
        }

        public async Task<List<MoviesDto>> SortMovies(string sort)
        {
            var movies = await _repository.GetAll();
            if(sort == "asc")
            {
                movies = movies.OrderBy(x => x.Rating).ToList();
            } 
            else if(sort == "desc")
            {
                movies = movies.OrderByDescending(x => x.Rating).ToList();
            }
            var sortedMoviesDto = _mapper.Map<List<MoviesDto>>(movies);
            return sortedMoviesDto;
        }
    }
}
