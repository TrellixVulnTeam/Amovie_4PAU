using Amovie.Models;
using Amovie.Models.NewsDto;
using AutoMapper;
using Entities.Models.MovieDto;
using Entities.Models.NewsDto;

namespace Entities.Profiler
{
    public class MovieProfiler : Profile
    {
        public MovieProfiler()
        {
            //movie
            CreateMap<Movie, LastMovieDto>().ReverseMap();
            CreateMap<Movie, PagedMovieDto>().ReverseMap();
            CreateMap<Movie, MoviesDto>().ReverseMap();
            CreateMap<Movie, AddMovieDto>().ReverseMap();
            CreateMap<Movie, SingleMovieDto>().ReverseMap();

            //news
            CreateMap<News, GetNewsDto>().ReverseMap();
            CreateMap<News, UpdateNewsDto>().ReverseMap();
            CreateMap<News, UpdateNewsDto>().ReverseMap();
            CreateMap<PagedNewsDto, News>().ReverseMap();

        }
    }
}
