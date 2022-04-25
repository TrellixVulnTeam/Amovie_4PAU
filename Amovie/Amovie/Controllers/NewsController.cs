using Amovie.Models.NewsDto;
using Behaviour.Interfaces;
using Entities.Models.NewsDto;
using Microsoft.AspNetCore.Mvc;

namespace Amovie.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<ActionResult<List<GetNewsDto>>> Get()
        {
            return await _newsService.GetNews();
        }

        //Get last 3 News
        [HttpGet("lastnews")]
        public async Task<ActionResult<List<GetNewsDto>>> GetLast()
        {
            return await _newsService.GetLast();
        }


        //Get News by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<GetNewsDto>> GetNews(int id)
        {
            return await _newsService.GetSingleNews(id); 
        }

        //Add News
        [HttpPost]
        public async Task Add(AddNewsDto news)
        {
            await _newsService.AddNews(news);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _newsService.DeleteNews(id);
        }

        //Update News
        [HttpPut("{id}")]
        public async Task Update(UpdateNewsDto news, int id)
        {
            await _newsService.UpdateNews(news, id);
        }
    }
}
