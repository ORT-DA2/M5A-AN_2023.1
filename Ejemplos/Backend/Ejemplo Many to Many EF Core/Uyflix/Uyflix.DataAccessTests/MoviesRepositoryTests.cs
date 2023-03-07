using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Uyflix.DataAccess;
using Uyflix.DataAccess.Repositories;
using Uyflix.Domain.Entities;

namespace Uyflix.DataAccessTests
{
    [TestClass]
    public class MoviesRepositoryTests
    {
        private MoviesRepository moviesRepository;
        [TestInitialize]
        public void InitTests()
        {
            Movie iceAge = new Movie()
            {
                Name = "La Era de Hielo",
                Year = 2002
            };

            var options = new DbContextOptionsBuilder<UyflixContext>()
                .UseInMemoryDatabase("UyflixTestDB")
                .Options;
            DbContext context = new UyflixContext(options);

            context.Database.EnsureDeleted();

            context.Set<Movie>().Add(iceAge);
            context.SaveChanges();

            moviesRepository = new MoviesRepository(context);
        }
        [TestMethod]
        public void GetAllMoviesOk()
        {
            IQueryable<Movie> movies = moviesRepository.GetAllMovies();
            Assert.AreEqual(1, movies.Count());
        }
        [TestMethod]
        public void InsertMoviesOk()
        {
            Movie madagascar = new Movie
            {
                Name = "Madagascar",
                Year = 2005,
                MoviesCategories = new List<MovieCategory>(),
                Starring = new List<Actor>()
            };
            moviesRepository.InsertMovie(madagascar);
            moviesRepository.Save();
            Assert.AreNotEqual(0, madagascar.Id);
        }
        [TestMethod]
        public void GetMovieByIdOk()
        {
            Movie movie = moviesRepository.GetMovieById(1);
            Assert.AreEqual("La Era de Hielo", movie.Name);
        }
        [TestMethod]
        public void UpdateMovieOk()
        {
            Movie movie = moviesRepository.GetMovieById(1);
            Actor actor = new Actor
            {
                FirstName = "Name",
                LastName = "Surname",
                Movies = new List<Movie>()
            };
            movie.Starring.Add(actor);
            moviesRepository.UpdateMovie(movie);
            moviesRepository.Save();

            Movie movieGetted = moviesRepository.GetMovieById(1);
            Assert.AreEqual(1, movieGetted.Starring.Count);
        }
    }
}
