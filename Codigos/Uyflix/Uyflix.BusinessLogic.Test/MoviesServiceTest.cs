using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Uyflix.BusinessLogic;
using Uyflix.Domain;
using Uyflix.Exceptions;
using Uyflix.IDataAccess;

namespace Uyflix.BusinessLogic.Test
{
    [TestClass]
    public class MoviesServiceTest
    {
        private Mock<IMoviesManagement> mock;
        private MoviesService service;
        private Movie iceAge;
        private Movie nullMovie;
        private IEnumerable<Movie> movies;
        private Movie invalidMovie;

        [TestInitialize]
        public void InitTest()
        {
            mock = new Mock<IMoviesManagement>(MockBehavior.Strict);
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

        [TestMethod]
        public void GetAllMovies()
        {
            mock.Setup(x => x.GetMovies()).Returns(movies);
            service.GetMovies();
            mock.VerifyAll();
        }

        [ExpectedException(typeof(BusinessLogicException))]
        [TestMethod]
        public void InsertNullMovie()
        {
            service.InsertMovie(nullMovie);
            mock.VerifyAll();
        }
        [ExpectedException(typeof(BusinessLogicException))]
        [TestMethod]
        public void InsertInvalidMovie()
        {
            service.InsertMovie(invalidMovie);
            mock.VerifyAll();
        }
        [ExpectedException(typeof(BusinessLogicException))]
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
            service.InsertMovie(iceAge);
            mock.VerifyAll();
        }

        [ExpectedException(typeof(BusinessLogicException))]
        [TestMethod]
        public void UpdateNullMovie()
        {
            service.UpdateMovie(nullMovie);
            mock.VerifyAll();
        }
        [ExpectedException(typeof(BusinessLogicException))]
        [TestMethod]
        public void UpdateInvalidMovie()
        {
            service.UpdateMovie(invalidMovie);
            mock.VerifyAll();
        }
        [ExpectedException(typeof(BusinessLogicException))]
        [TestMethod]
        public void UpdateMovieWithOurRangeRating()
        {
            iceAge.Rating = 10;
            service.UpdateMovie(iceAge);
            mock.VerifyAll();
        }
        [ExpectedException(typeof(NotFoundException))]
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
            service.UpdateMovie(iceAge);
            mock.VerifyAll();
        }

        [ExpectedException(typeof(NotFoundException))]
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
            mock.Setup(x => x.GetMovieById(1)).Returns(iceAge);
            mock.Setup(x => x.DeleteMovie(iceAge));
            service.DeleteMovie(1);
            mock.VerifyAll();
        }
    }
}
