using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uyflix.Domain.Entities;

namespace Uyflix.Domain.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public IEnumerable<CategoryModel> Categories { get; set; }
        public IEnumerable<ActorModel> Starring { get; set; }
        public MovieModel() { }
        public MovieModel(Movie movie)
        {
            this.Id = movie.Id;
            this.Name = movie.Name;
            this.Year = movie.Year;
            this.Categories = movie.MoviesCategories.Select(c => new CategoryModel(c.Category));
            this.Starring = movie.Starring.Select(a => new ActorModel(a));
        }
        public Movie ToEntity()
        {
            return new Movie
            {
                Id = this.Id,
                Name = this.Name,
                Year = this.Year,
                MoviesCategories = this.Categories.Select(c =>
                new MovieCategory
                {
                    CategoryId = c.Id,
                    Category = c.ToEntity(),
                })
                .ToList(),
                Starring = this.Starring.Select(a => a.ToEntity()).ToList()
            };
        }
    }
}
