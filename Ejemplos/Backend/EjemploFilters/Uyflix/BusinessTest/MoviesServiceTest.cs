using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Uyflix.IDataAccess;
using Uyflix.Business;
using System;
using Uyflix.Domain.Entities;
using System.Collections.Generic;

namespace Uyflix.BusinessTest
{
    [TestClass]
    public class MoviesServiceTest
    {
        private Mock<IMoviesManagment> mock;
        private MoviesService service;
        private Movie iceAge;
        private Movie nullMovie;
        private IEnumerable<Movie> movies;
        private Movie invalidMovie;
        [TestInitialize]
        public void InitTest()
        {
            mock = new Mock<IMoviesManagment>(MockBehavior.Strict);
            service = new MoviesService(mock.Object);
            iceAge = new Movie()
            {
                Id = 1,
                Category = "Animada",
                Country = "Estados Unidos",
                Director = "Chris Wedge y Carlos Saldanha",
                Name = "La Era de Hielo",
                Rating = 5,
                Year = 2002
            };
            nullMovie = null;
            movies = new List<Movie>() { iceAge };
            invalidMovie = new Movie() { Name = "" };
        }
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void DeleteMovieLessThanZero()
        {
            service.DeleteMovie(-1);
            mock.VerifyAll();
        }
        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void DeleteMovieNonExist()
        {
            mock.Setup(x => x.GetMovieById(10)).Returns(nullMovie);
            service.DeleteMovie(10);
            mock.VerifyAll();
        }
        [TestMethod]
        public void DeleteMovieOk()
        {
            mock.Setup(x => x.GetMovieById(3)).Returns(iceAge);
            mock.Setup(x => x.DeleteMovie(iceAge));
            mock.Setup(x => x.Save());
            service.DeleteMovie(3);
            mock.VerifyAll();
        }
        [TestMethod]
        public void GetFilterMovies()
        {
            Movie movieFilter = new Movie()
            {
                Name = "La Era de Hielo"
            };
            mock.Setup(x => x.GetMovies(It.IsAny<Func<Movie, bool>>())).Returns(movies);
            service.GetMovies(movieFilter);
            mock.VerifyAll();
        }
        [TestMethod]
        public void GetAllMovies()
        {
            Movie movieFilter = new Movie();
            mock.Setup(x => x.GetMovies()).Returns(movies);
            service.GetMovies(movieFilter);
            mock.VerifyAll();
        }
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void InsertNullMovie()
        {
            service.InsertMovie(nullMovie);
            mock.VerifyAll();
        }
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void InsertInvalidMovie()
        {
            service.InsertMovie(invalidMovie);
            mock.VerifyAll();
        }
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void InsertMovieWithOurRangeRating()
        {
            iceAge.Rating = 10;
            service.InsertMovie(iceAge);
            mock.VerifyAll();
        }
        [TestMethod]
        public void InsertMovieOk()
        {
            mock.Setup(x => x.InsertMovie(iceAge));
            mock.Setup(x => x.Save());
            service.InsertMovie(iceAge);
            mock.VerifyAll();
        }
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void UpdateNullMovie()
        {
            service.UpdateMovie(nullMovie);
            mock.VerifyAll();
        }
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void UpdateInvalidMovie()
        {
            service.UpdateMovie(invalidMovie);
            mock.VerifyAll();
        }
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void UpdateMovieWithOurRangeRating()
        {
            iceAge.Rating = 10;
            service.UpdateMovie(iceAge);
            mock.VerifyAll();
        }
        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void UpdateMovieNonExist()
        {
            mock.Setup(x => x.GetMovieById(iceAge.Id)).Returns(nullMovie);
            service.UpdateMovie(iceAge);
            mock.VerifyAll();
        }
        [TestMethod]
        public void UpdateMovieOk()
        {
            mock.Setup(x => x.GetMovieById(It.IsAny<int>())).Returns(iceAge);
            mock.Setup(x => x.UpdateMovie(It.IsAny<Movie>()));
            mock.Setup(x => x.Save());
            service.UpdateMovie(iceAge);
            mock.VerifyAll();
        }
    }
}
