namespace Amovie.Models.NewsDto
{
    public class GetNewsDto
    {
        public int NewsId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
    }
}
