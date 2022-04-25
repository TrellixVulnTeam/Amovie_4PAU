
namespace Entities.Models.NewsDto
{
    public class AddNewsDto
    {
        public int NewId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int AuthorId { get; set; }
    }
}
