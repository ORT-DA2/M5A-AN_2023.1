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
    public class MoviesServiceTest2
    {
        [TestInitialize]
        public void InitTest()
        {
            
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void UpdateMovieNull()
        {
            Mock<IMoviesManagment> mock = new Mock<IMoviesManagment>(MockBehavior.Strict);
            MoviesService service = new MoviesService(mock.Object);

            service.UpdateMovie(null);

            mock.VerifyAll();
        }

        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void UpdateMovieNotExits()
        {
            Mock<IMoviesManagment> mock = new Mock<IMoviesManagment>(MockBehavior.Strict);
            MoviesService service = new MoviesService(mock.Object);

            Movie movie = new Movie()
            {
                Id = 1,
                Category = "Animada",
                Country = "Estados Unidos",
                Director = "Chris Wedge y Carlos Saldanha",
                Name = "La Era de Hielo",
                Rating = 5,
                Year = 2002
            };
            Movie movieNull = null;

            mock.Setup(moviesManagment => moviesManagment.GetMovieById(movie.Id)).Returns(movieNull);

            service.UpdateMovie(movie);

            mock.VerifyAll();
        }

        [TestMethod]
        public void UpdateMovieOk()
        {
            Mock<IMoviesManagment> mock = new Mock<IMoviesManagment>(MockBehavior.Strict);
            MoviesService service = new MoviesService(mock.Object);

            Movie movie = new Movie()
            {
                Id = 1,
                Category = "Animada",
                Country = "Estados Unidos",
                Director = "Chris Wedge y Carlos Saldanha",
                Name = "La Era de Hielo",
                Rating = 5,
                Year = 2002
            };

            mock.Setup(moviesManagment => moviesManagment.GetMovieById(It.IsAny<int>())).Returns(movie);
            mock.Setup(moviesManagment => moviesManagment.UpdateMovie(It.IsAny<Movie>()));

            service.UpdateMovie(movie);

            mock.VerifyAll();
        }


    }
}
