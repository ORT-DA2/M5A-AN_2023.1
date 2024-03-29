﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using Domain;
using IDataAccess;

namespace DataAccess.Test
{
    [TestClass]
    public class MoviesManagementTest
    {
        private Movie? iceAge;
        private List<Movie>? movies;

        [TestInitialize]
        public void InitTest()
        {
            iceAge = new Movie(
                "La Era de Hielo",
                "Animada",
                "Chris Wedge y Carlos Saldanha",
                "Estados Unidos",
                2002,
                5
            );

            movies = new List<Movie>() { iceAge };
        }

        [TestMethod]
        public void GetMoviesOk()
        {
            IMoviesManagement moviesManagement = CreateMoviesManagement();
            IEnumerable<Movie>? moviesInDatabase = moviesManagement.GetMovies();

            Assert.AreEqual(moviesInDatabase?.ToList().Count, movies!.Count);
            Assert.AreEqual(moviesInDatabase?.ToList()[0].Name, movies[0].Name);
        }

        [TestMethod]
        public void GetMovieByIdOk()
        {
            UyflixContext context = CreateContext();
            IMoviesManagement moviesManagement = new MoviesManagement(context);

            context.Movies?.Add(iceAge!);
            context.SaveChanges();

            Movie? movieInDatabase = moviesManagement.GetMovieById(iceAge!.Id);

            Assert.IsNotNull(movieInDatabase);
            Assert.AreEqual(movieInDatabase.Name, iceAge.Name);
        }

        [TestMethod]
        public void InsertMovieOk()
        {
            UyflixContext context = CreateContext();
            IMoviesManagement moviesManagement = new MoviesManagement(context);

            moviesManagement.InsertMovie(iceAge!);

            Movie? movieInDatabase = context.Movies?.Where<Movie>(movie => movie.Id == iceAge!.Id).AsNoTracking().FirstOrDefault();

            Assert.IsNotNull(movieInDatabase);
            Assert.AreEqual(movieInDatabase?.Name, iceAge!.Name);
        }

        [TestMethod]
        public void DeleteMovieOk()
        {
            UyflixContext context = CreateContext();
            IMoviesManagement moviesManagement = new MoviesManagement(context);

            context.Movies?.Add(iceAge!);
            context.SaveChanges();

            moviesManagement.DeleteMovie(iceAge!);

            Movie? movieInDatabase = context.Movies?.Where<Movie>(movie => movie.Id == iceAge!.Id).AsNoTracking().FirstOrDefault();

            Assert.IsNull(movieInDatabase);
        }

        [TestMethod]
        public void UpdateMovieOk()
        {
            UyflixContext context = CreateContext();
            IMoviesManagement moviesManagement = new MoviesManagement(context);

            context.Movies?.Add(iceAge!);
            context.SaveChanges();
            iceAge!.Rating = 4;
            moviesManagement.UpdateMovie(iceAge);

            Movie? movieInDatabase = context.Movies?.Where<Movie>(movie => movie.Id == iceAge.Id).AsNoTracking().FirstOrDefault();

            Assert.IsNotNull(movieInDatabase);
            Assert.AreEqual(movieInDatabase?.Rating, iceAge.Rating);
        }


        private IMoviesManagement CreateMoviesManagement()
        {
            var context = CreateContext();

            context.Movies?.Add(iceAge!);
            context.SaveChanges();

            IMoviesManagement moviesManagement = new MoviesManagement(context);
            return moviesManagement;
        }

        private UyflixContext CreateContext()
        {
            var contextOptions = new DbContextOptionsBuilder<UyflixContext>()
                .UseInMemoryDatabase("MoviesDb")
                .Options;

            var context = new UyflixContext(contextOptions);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            return context;
        }
    }
}

