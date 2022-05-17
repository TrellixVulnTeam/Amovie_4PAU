using Behaviour.Interfaces;
using Entities.Models.NewsDto;
using Microsoft.AspNetCore.Mvc;

namespace Amovie.Controllers
{
    [Route("api/")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        //Get all News
        [HttpGet("allnews")]
        public async Task<ActionResult<List<NewsDto>>> GetAllNews()
        {
            var newsList = await _newsService.GetAll();
            return newsList;
        }

        ////Get last 3 News
        [HttpGet("lastnews")]
        public async Task<ActionResult<List<NewsDto>>> GetLast()
        {
            var newsList = await _newsService.GetLast();
            return Ok(newsList);
        }

        ////Get News by ID
        [HttpGet("news/{id}")]
        public async Task<ActionResult<NewsDto>> GetNews(int id)
        {
            var news = await _newsService.GetNews(id);
            if (news == null)
                return NotFound("Such ID does not exists!");
            return Ok(news);
        }

        ////Add News
        [HttpPost("/addnews")]
        public async Task Add(AddNewsDto newsDto)
        {
            await _newsService.AddNews(newsDto);
        }

        [HttpDelete("deletenews/{id}")]
        public async Task Delete(int id)
        {
           await _newsService.DeleteNews(id);
        }

        ////Update News
        [HttpPut("{id}")]
        //[ApiExceptionFilter]
        public async Task Update(AddNewsDto newsDto, int id)
        {
            await _newsService.UpdateNews(newsDto, id);
        }

        ////GetPaggedNews
        [HttpGet("/newspage/{page}")]
        public async Task<ActionResult<PagedNewsDto>> GetPagedNews(int page, int pageSize)
        {
            var pagedNews = await _newsService.GetPagedNews(page, pageSize);

            return Ok(pagedNews);
        }
    }
}
