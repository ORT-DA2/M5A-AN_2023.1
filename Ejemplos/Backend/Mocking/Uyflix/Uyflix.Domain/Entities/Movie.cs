using System;

namespace Uyflix.Domain.Entities
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
        public bool IsValid()
        {
            if (Name == null || Name == "") return false;
            if (Category == null || Category == "") return false;
            if (Director == null || Director == "") return false;
            if (Country == null || Country == "") return false;
            if (Year < 0) return false;
            if (Rating < 1) return false;
            return true;
        }
    }
}
