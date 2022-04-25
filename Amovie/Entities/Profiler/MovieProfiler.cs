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


            //news
            CreateMap<News, GetNewsDto>(MemberList.Source)
                 .ForPath(dest => dest.AuthorFirstName,
            opt => opt.MapFrom(src => src.Author!.FirstName))
                 .ForPath(dest =>dest.AuthorLastName,
                        opt => opt.MapFrom(src => src.Author!.LastName))
                 .ReverseMap();

            CreateMap<UpdateNewsDto, News>().ReverseMap();
            CreateMap<AddNewsDto, News>().ReverseMap();
        }
    }
}
