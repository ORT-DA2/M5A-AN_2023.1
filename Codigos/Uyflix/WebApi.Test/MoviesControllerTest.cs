using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Domain;
using Exceptions;
using IBusinessLogic;
using WebApi.Controllers;
using WebApi.DTOs;

namespace WebApi.Test
{
    [TestClass]
    public class MoviesControllerTest
    {
        private Mock<IMoviesService>? mock;
        private MoviesController? api;
        private Movie? iceAge;
        private CreateMovieRequestDTO? iceAgeDTO;
        private IEnumerable<Movie>? movies;
        [TestInitialize]
        public void InitTest()
        {
            mock = new Mock<IMoviesService>(MockBehavior.Strict);
            api = new MoviesController(mock.Object);
            iceAge = new Movie(
                "La Era de Hielo",
                "Animada",
                "Chris Wedge y Carlos Saldanha",
                "Estados Unidos",
                2002,
                5
            );
            iceAgeDTO = new CreateMovieRequestDTO
            {
                Name = iceAge.Name,
                Category = iceAge.Category,
                Director = iceAge.Director,
                Country = iceAge.Country,
                Year = iceAge.Year,
                Rating = iceAge.Rating,
            };
            movies = new List<Movie>() { iceAge };
        }

        [TestMethod]
        public void GetMoviesOk()
        {
            mock!.Setup(x => x.GetMovies()).Returns(movies!);

            var result = api!.GetMovies();
            var objectResult = result as ObjectResult;
            var statusCode = objectResult?.StatusCode;

            mock.VerifyAll();
            Assert.AreEqual(200, statusCode);
        }

        [TestMethod]
        public void GetMoviesFail()
        {
            mock!.Setup(x => x.GetMovies()).Throws(new Exception());

            var result = api!.GetMovies();
            var objectResult = result as ObjectResult;
            var statusCode = objectResult?.StatusCode;

            mock.VerifyAll();
            Assert.AreEqual(500, statusCode);
        }

        [TestMethod]
        public void PostMovieBadRequest()
        {
            iceAge!.Rating = 10;
            iceAgeDTO!.Rating = 10;
            mock!.Setup(x => x.InsertMovie(It.IsAny<Movie>())).Throws(new BusinessLogicException());
            var result = api!.PostMovie(iceAgeDTO!);
            var objectResult = result as ObjectResult;
            var statusCode = objectResult?.StatusCode;

            mock.VerifyAll();
            Assert.AreEqual(400, statusCode);
        }

        [TestMethod]
        public void PostMovieFail()
        {
            mock!.Setup(x => x.InsertMovie(It.IsAny<Movie>())).Throws(new Exception());
            var result = api!.PostMovie(iceAgeDTO!);
            var objectResult = result as ObjectResult;
            var statusCode = objectResult?.StatusCode;

            mock.VerifyAll();
            Assert.AreEqual(500, statusCode);
        }

        [TestMethod]
        public void PostMovieOk()
        {
            mock!.Setup(x => x.InsertMovie(It.IsAny<Movie>())).Returns(iceAge);
            var result = api!.PostMovie(iceAgeDTO!);
            var objectResult = result as ObjectResult;
            var statusCode = objectResult?.StatusCode;

            mock.VerifyAll();
            Assert.AreEqual(200, statusCode);
        }

        [TestMethod]
        public void PutMovieBadRequest()
        {
            mock!.Setup(x => x.UpdateMovie(iceAge!)).Throws(new BusinessLogicException());
            var result = api!.PutMovie(iceAge!.Id, iceAge);
            var objectResult = result as ObjectResult;
            var statusCode = objectResult?.StatusCode;

            mock.VerifyAll();
            Assert.AreEqual(400, statusCode);
        }

        [TestMethod]
        public void PutMovieNotFound()
        {
            mock!.Setup(x => x.UpdateMovie(iceAge!)).Throws(new NotFoundException());
            var result = api!.PutMovie(iceAge!.Id, iceAge);
            var objectResult = result as ObjectResult;
            var statusCode = objectResult?.StatusCode;

            mock.VerifyAll();
            Assert.AreEqual(404, statusCode);
        }

        [TestMethod]
        public void PutMovieFail()
        {
            mock!.Setup(x => x.UpdateMovie(iceAge!)).Throws(new Exception());
            var result = api!.PutMovie(iceAge!.Id, iceAge);
            var objectResult = result as ObjectResult;
            var statusCode = objectResult?.StatusCode;

            mock.VerifyAll();
            Assert.AreEqual(500, statusCode);
        }

        [TestMethod]
        public void PutMovieOk()
        {
            mock!.Setup(x => x.UpdateMovie(iceAge!)).Returns(It.IsAny<Movie>());
            var result = api!.PutMovie(iceAge!.Id, iceAge);
            var objectResult = result as ObjectResult;
            var statusCode = objectResult?.StatusCode;

            mock.VerifyAll();
            Assert.AreEqual(200, statusCode);
        }

        [TestMethod]
        public void DeleteMovieNotFound()
        {
            mock!.Setup(x => x.DeleteMovie(It.IsAny<int>())).Throws(new NotFoundException());
            var result = api!.DeleteMovie(It.IsAny<int>());
            var objectResult = result as ObjectResult;
            var statusCode = objectResult?.StatusCode;

            mock.VerifyAll();
            Assert.AreEqual(404, statusCode);
        }

        [TestMethod]
        public void DeleteMovieFail()
        {
            mock!.Setup(x => x.DeleteMovie(It.IsAny<int>())).Throws(new Exception());
            var result = api!.DeleteMovie(It.IsAny<int>());
            var objectResult = result as ObjectResult;
            var statusCode = objectResult?.StatusCode;

            mock.VerifyAll();
            Assert.AreEqual(500, statusCode);
        }

        [TestMethod]
        public void DeleteMovieOk()
        {
            mock!.Setup(x => x.DeleteMovie(iceAge!.Id));
            var result = api!.DeleteMovie(iceAge!.Id);
            var objectResult = result as OkObjectResult;
            var statusCode = objectResult?.StatusCode;

            mock.VerifyAll();
            Assert.AreEqual(200, statusCode);
        }
    }
}
