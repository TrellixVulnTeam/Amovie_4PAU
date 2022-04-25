﻿using Amovie.Models;

namespace Entities.Models.MovieDto
{
    public class PagedMovieDto
    {
        public IEnumerable<MoviesDto> Movies { get; set; }
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
