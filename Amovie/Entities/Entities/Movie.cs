using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Amovie.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        [Range(typeof(DateTime), "1/1/1900", "1/1/2022")]
        public DateTime Release { get; set; }
        [Range(1, 10)]
        public float Rating { get; set; }
        public int Duration { get; set; }
        public string Country { get; set; }
        public float Budget { get; set; }
        [JsonIgnore]
        public List<Review>? Reviews { get; set; }
        [JsonIgnore]
        public List<Genre>? Genres { get; set; }
        [JsonIgnore]
        public List<Actor>? Actors { get; set; }
    }
}
