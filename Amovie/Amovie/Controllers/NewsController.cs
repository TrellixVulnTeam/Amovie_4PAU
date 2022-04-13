using Amovie.Data;
using Amovie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Amovie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly DataContext _context;

        public NewsController(DataContext context)
        {
            _context = context;
        }

        //Get all News
        [HttpGet("allnews")]
        public async Task<ActionResult<List<News>>> Get()
        {
            var news = await _context.News.ToListAsync();
            var authors = await _context.Authors.ToListAsync();

            var allNews = from n in news
                          join a in authors
                          on n.Author.AuthorId equals a.AuthorId
                          select new
                          {
                              Content = n.Content,
                              Date = n.Date,
                              Image = n.Image,
                              Title = n.Title,
                              Author = a.FirstName + " " + a.LastName
                          };
            return Ok(allNews);
        }

        //Get last 3 Movies
        [HttpGet("lastnews")]
        public async Task<ActionResult<List<NewsModel>>> GetLast()
        {
            //List<NewsModel> newsList = new List<NewsModel>();

            //var lastNews = await _context.News
            //    .Include(a => a.Author)
            //    .Skip(Math
            //    .Max(0, _context.News
            //    .Count() - 3))
            //    .ToListAsync();

            //var authors = await _context.Authors.ToListAsync();

            //foreach (var item in lastNews)
            //{
            //    var newsResult = new NewsModel
            //    {
                      //NewsId = x.NewsId,
            //        Content = item.Content,
            //        Date = item.Date,
            //        Image = item.Image,
            //        Title = item.Title,
            //        Author = item.Author.FirstName + " " + item.Author.LastName
            //    };
            //    newsList.Add(newsResult);
            //}

            var latestNews = await _context.News.Include(a => a.Author).Select(x => new NewsModel
            {
                NewsId = x.NewsId,
                Content = x.Content,
                Date = x.Date,
                Image = x.Image,
                Title = x.Title,
                Author = x.Author.FirstName + " " + x.Author.LastName
            }).Skip(Math
                .Max(0, _context.News
                .Count() - 3))
                .ToListAsync();

            return Ok(latestNews);
        }


        //Get News by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<News>> GetNews(int id)
        {
            var news = await _context.News.FindAsync(id);

            if (news == null)
            {
                return BadRequest("News not found!");
            }
            else
            {
                return Ok(news);
            }
        }
    }
}
