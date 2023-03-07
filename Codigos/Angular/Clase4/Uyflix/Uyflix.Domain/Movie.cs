using System;
namespace Uyflix.Domain
{
    public class Movie
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Director { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }
        public int Rating { get; set; }

        public Movie() { }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Movie movie = obj as Movie;
            if (movie == null)
            {
                return false;
            }
            return this.Id == movie.Id;
        }

        public override int GetHashCode()
        {
            return this.Id;
        }
    }
}
