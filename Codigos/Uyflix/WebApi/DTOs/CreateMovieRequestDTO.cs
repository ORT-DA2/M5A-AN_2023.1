using System;
using Domain;

namespace WebApi.DTOs
{
	public class CreateMovieRequestDTO
	{
        public string Name { get; set; }
        public string Category { get; set; }
        public string Director { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }
        public int Rating { get; set; }

        public CreateMovieRequestDTO() { }

        public Movie TransformToMovie()
        {
            return new Movie(
                this.Name,
                this.Category,
                this.Director,
                this.Country,
                this.Year,
                this.Rating
            );
        } 
	}
}

