namespace Amovie.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public Movie Movie { get; set; }
    }
}
