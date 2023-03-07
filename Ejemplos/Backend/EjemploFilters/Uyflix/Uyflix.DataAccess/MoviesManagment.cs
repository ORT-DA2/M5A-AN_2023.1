using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Uyflix.Domain.Entities;
using Uyflix.IDataAccess;
using System.Linq;

namespace Uyflix.DataAccess
{
    public class MoviesManagment : IMoviesManagment
    {
        private readonly DbSet<Movie> movies;
        private readonly DbContext context;
        public MoviesManagment(DbContext context)
        {
            movies = context.Set<Movie>();
            this.context = context;
        }

        public void DeleteMovie(Movie movie)
        {
            movies.Remove(movie);
        }

        public Movie GetMovieById(int id)
        {
            return movies.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Movie> GetMovies(Func<Movie, bool> filter)
        {
            return movies.Where(filter);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return movies;
        }

        public void InsertMovie(Movie movie)
        {
            movies.Add(movie);
        }

        public void UpdateMovie(Movie movie)
        {
            movies.Update(movie);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
