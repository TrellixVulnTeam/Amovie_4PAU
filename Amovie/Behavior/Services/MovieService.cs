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

        public async Task DeleteMovie(int id)
        {
            var movie = _repository.GetAll().FirstOrDefault(m => m.Id == id);


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

       

        public async Task<PagedMovieDto> GetPagedMovies(int page, int pageSize)
        {
            //var pageResults = 2f;

            var pageCount = Math.Ceiling(_repository.GetAll().Count() / (float)pageSize);

            var movies = _repository.GetAll()
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
    }
}
