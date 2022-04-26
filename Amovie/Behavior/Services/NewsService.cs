using Amovie.Models.NewsDto;
using Behaviour.Interfaces;
using Amovie.Data;
using Microsoft.EntityFrameworkCore;
using Amovie.Models;
using Entities.Models.NewsDto;
using AutoMapper;
using Behaviour.Abstract;
using Entities.Exceptions;

namespace Behaviour.Services
{
    public class NewsService : GenericRepository<News>, INewsService
    {
        public readonly IRepository<News> _repository;
        private readonly IMapper _mapper;

        public NewsService(IRepository<News> repository, IMapper mapper, DataContext context) : base(context)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetNewsDto>> GetLast()
        {
            var latestNews = _context.News
                .Include(a => a.Author)
                .Skip(Math
                .Max(0, _context.News
                .Count() - 3));

            var newsDto = _mapper.Map<List<GetNewsDto>>(latestNews);

            return newsDto;
        }

        public async Task<List<GetNewsDto>> GetNews()
        {
            var news = _context.News.Include(x => x.Author);

            if (news == null)
            {
                throw new Exception("News not found");
            }
            else
            {
                var newsDto = _mapper.Map<List<GetNewsDto>>(news);
                return newsDto;
            }
        }

        public async Task<GetNewsDto> GetSingleNews(int id)
        {
            var news = await _context.News.Include(x => x.Author).FirstOrDefaultAsync(x => x.NewsId == id);


            if (news == null)
            {
                throw new Exception("News with such id does not exist!");
            }
            else
            {
                var newsDto = _mapper.Map<GetNewsDto>(news);
                return newsDto;
            }
        }

        public async Task AddNews(AddNewsDto news)
        {
            var newsDto = _mapper.Map<News>(news);
            _repository.Add(newsDto);
            _repository.SaveChangesAsync();
        }

        public async Task DeleteNews(int id)
        {
            var news = _repository.Get(id);
            if (news == null)
            {
                throw new Exception("News not found");
            }
            else
            {
                _repository.Delete(news);
                _repository.SaveChangesAsync();
            }
        }

        public async Task UpdateNews(UpdateNewsDto news, int id)
        {
            var movieDb =  _repository.Get(id);

            if(movieDb == null)
            {
                throw new NotFoundException("News with such id can not be found!");
            }
            else
            {
                _mapper.Map(news, movieDb);
                _repository.Update(movieDb);
                _repository.SaveChangesAsync();
            }
        }

        public async Task<PagedNewsDto> GetPagedNews(int page)
        {

            var pageResults = 2f;

            var pageCount = Math.Ceiling(_repository.GetAll().Count() / pageResults);

            var news = _context.News.Include(x => x.Author)
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults);

            var newsDto = _mapper.Map<List<GetNewsDto>>(news);

            var response = new PagedNewsDto
            {
                News = newsDto,
                CurrentPage = page,
                Pages = (int)pageCount
            };
            return response;

        }



        //public async Task<List<GetNewsDto>> GetLast()
        //{
        //    var latestNews = await _context.News
        //        .Include(a => a.Author)
        //        .Select(x => new GetNewsDto
        //        {
        //            NewsId = x.NewsId,
        //            Title = x.Title,
        //            Image = x.Image,
        //            Content = x.Content,
        //            Date = x.Date,
        //            AuthorFirstName = x.Author.FirstName,
        //            AuthorlastName = x.Author.LastName
        //        }).Skip(Math
        //        .Max(0, _context.News
        //        .Count() - 3))
        //        .ToListAsync();

        //    return latestNews;
        //}

        //public async Task<GetNewsDto> GetNews(int id)
        //{
        //    var news = await _context.News.FindAsync(id);

        //    if (news == null)
        //    {
        //        throw new Exception("News not found");
        //    }
        //    else
        //    {
        //        var newsDto = _mapper.Map<GetNewsDto>(news);
        //        return newsDto;
        //    }
        //}



        //public async Task Update(UpdateNewsDto news, int id)
        //{
        //    var newsDb = await _context.News.FindAsync(id);

        //    if (newsDb == null)
        //    {
        //        throw new Exception("News not found");
        //    }
        //    else
        //    {
        //        var NewsDto = _mapper.Map<UpdateNewsDto>(newsDb);
        //        newsDb.Title = news.Title;
        //        newsDb.Image = news.Image;
        //        newsDb.Content = news.Content;
        //        newsDb.Date = news.Date;
        //        newsDb.AuthorId = news.AuthorId;
        //    }
        //    _context.SaveChangesAsync();
        //}


    }
}
