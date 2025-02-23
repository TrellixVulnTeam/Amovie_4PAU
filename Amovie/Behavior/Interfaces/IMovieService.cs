﻿using Entities.Models.MovieDto;


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
        Task<List<MoviesDto>> FilterMovies(string title);
        Task<List<MoviesDto>> SortMovies(string sort);
        Task<PagedMovieDto> GetPagedMovies(int page, int pageSize);
    }
}
