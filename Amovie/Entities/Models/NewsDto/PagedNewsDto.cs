

using Amovie.Models.NewsDto;

namespace Entities.Models.NewsDto
{
    public class PagedNewsDto
    {
        public IEnumerable<GetNewsDto> News { get; set; }
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
