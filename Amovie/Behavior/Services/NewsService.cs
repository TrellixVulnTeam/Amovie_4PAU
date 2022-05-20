using Behaviour.Interfaces;
using AutoMapper;
using Entities.Entities;
using Entities.Models.NewsDto;
using Microsoft.AspNetCore.Mvc;
using Entities.Exceptions;

namespace Behaviour.Services
{
    public class NewsService : INewsService
    {
        private readonly IRepository<News> _repository;
        private readonly IMapper _mapper;
        public NewsService(IRepository<News> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<NewsDto>> GetAll()
        {
            var newsWithInclude = _repository.GetAllWithIncludes(x => x.Author);
            var newsDto = _mapper.Map<List<NewsDto>>(newsWithInclude);

            return newsDto;
        }

        public async Task<List<NewsDto>> GetLast()
        {
            var allNews = await _repository.GetAll();
            var lastNews =  _repository.GetAllWithIncludes(x => x.Author).AsQueryable()
            .Skip(Math
            .Max(0, allNews
            .Count() - 3));

            var newsDto = _mapper.Map<List<NewsDto>>(lastNews);
            return newsDto;
        }

        public async Task<NewsDto> GetNews(int id)
        {
            var news =  await _repository.GetByIdWithIncludes(id, x=>x.Author);

            var newsDto = _mapper.Map<NewsDto>(news);

            if (news == null)
            {
                throw new Exception("News not found");
            }
            else
            {
                return newsDto;
            }
        }

        public async Task<PagedNewsDto> GetPagedNews(int page, int pageSize)
        {
            var allNews = await _repository.GetAll();
            var pageCount = Math.Ceiling(allNews.Count() / (float)pageSize);

            var news = _repository.GetAllWithIncludes(x => x.Author).AsQueryable()
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            var newsDto = _mapper.Map<List<NewsDto>>(news);

            var response = new PagedNewsDto
            {
                News = newsDto,
                CurrentPage = page,
                Pages = (int)pageCount
            };
            return response;
        }

        public async Task AddNews(AddNewsDto newsDto)
        {
            if (newsDto == null)
            {
                throw new ArgumentNullException(nameof(newsDto));
            }
            else
            {
                var news = _mapper.Map<News>(newsDto);
                await _repository.Add(news);
                await _repository.SaveChangesAsync();
            }
        }

        public async Task UpdateNews(AddNewsDto newsDto, int id)
        {
            var news = await _repository.Get(id);

            if (news == null)
            {
                throw new NotFoundException("News with such ID can not be found, please input an existent ID");
            }
            else
            {
                _mapper.Map(newsDto, news);
                await _repository.Update((News)news);
                await _repository.SaveChangesAsync();
            }
        }

        public async Task DeleteNews(int id)
        {
            var allNews = await _repository.GetAll();
            var news = allNews.FirstOrDefault(m => m.Id == id);

            if (news == null)
            {
                throw new Exception("News not found");
            }
            else
            {
                await _repository.Delete(news.Id);
                await _repository.SaveChangesAsync();
            }
        }

      
    }
}
