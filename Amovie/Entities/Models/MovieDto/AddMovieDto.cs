using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.MovieDto
{
    public class AddMovieDto
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
        public int GenreId { get; set; }
        public int ActorId { get; set; }
    }
}
