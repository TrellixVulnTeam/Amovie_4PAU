using Amovie.Models;
using Microsoft.EntityFrameworkCore;

namespace DataSeed
{
    public static class Seed
    {
        public static void SeedActors(this ModelBuilder builder)
        {
            builder.Entity<Actor>().HasData(new List<Actor>()
            {
                new Actor() { ActorId = 1, FirstName = "John", LastName = "Wick" },
                new Actor() { ActorId = 2, FirstName = "Tom", LastName = "Hollan" },
                new Actor() { ActorId = 3, FirstName = "Tony", LastName = "Stark" }
            });
        }

        public static void SeedGenres(this ModelBuilder builder)
        {
            builder.Entity<Genre>().HasData(new List<Genre>()
            {
                new Genre(){GenreId = 1, Name = "Comedy"},
                new Genre(){GenreId = 2, Name = "Horror"},
                new Genre(){GenreId = 3, Name = "Drama"},
            });
        }

        public static void SeedAuthors(this ModelBuilder builder)
        {
            builder.Entity<Author>().HasData(new List<Author>()
            {
                new Author(){AuthorId = 1, FirstName = "Mike", LastName = "Fredrick"},
                new Author(){AuthorId = 2, FirstName = "Terry", LastName = "Markus"},
                new Author(){AuthorId = 3, FirstName = "Luckas", LastName = "Francis"},
            });
        }
    }
}