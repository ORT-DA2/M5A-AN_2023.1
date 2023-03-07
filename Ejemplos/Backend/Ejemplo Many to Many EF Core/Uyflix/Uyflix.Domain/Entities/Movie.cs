using System;
using System.Collections.Generic;
using System.Text;

namespace Uyflix.Domain.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public ICollection<Actor> Starring { get; set; }
        public ICollection<MovieCategory> MoviesCategories { get; set; }
    }
}
