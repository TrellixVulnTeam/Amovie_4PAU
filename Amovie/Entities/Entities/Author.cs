﻿namespace Entities.Entities
{
    public class Author : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<News> News { get; set; }

    }
}
