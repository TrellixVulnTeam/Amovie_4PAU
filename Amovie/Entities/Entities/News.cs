namespace Amovie.Models
{
    public class News
    {
        public int NewsId { get; set; }
        public string Title { get; set;}
        public string Image { get; set;}
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public Author Author { get; set; }
    }
}
