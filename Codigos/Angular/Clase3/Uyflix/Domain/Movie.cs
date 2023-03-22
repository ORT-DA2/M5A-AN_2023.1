using System;
namespace Domain
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

        public Movie(string name, string category, string director, string country, int year, int rating)
        {
            Name = name;
            Category = category;
            Director = director;
            Country = country;
            Year = year;
            Rating = rating;
        }
    }
}

