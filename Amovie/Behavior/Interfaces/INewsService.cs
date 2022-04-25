using Amovie.Models;
using Amovie.Models.NewsDto;
using Entities.Models.NewsDto;

namespace Behaviour.Interfaces
{
    public interface INewsService
    {
        public Task<List<GetNewsDto>> GetNews();
        public Task<List<GetNewsDto>> GetLast();
        public Task<GetNewsDto> GetSingleNews(int id);
        public Task AddNews(AddNewsDto news);
        public Task DeleteNews(int id);
        public Task UpdateNews(UpdateNewsDto news, int id);
    }
}
