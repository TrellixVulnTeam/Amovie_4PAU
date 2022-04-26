

using Amovie.Models;

namespace Entities.Models.MovieDto
{
    public class SingleMovieDto
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public DateTime Release { get; set; }
        public float Rating { get; set; }
        public int Duration { get; set; }
        public string Country { get; set; }
        public float Budget { get; set; }
        public List<Review>? Reviews { get; set; }
        public List<Genre>? Genres { get; set; }
        public List<Actor>? Actors { get; set; }
    }
}
