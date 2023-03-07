using System;
using System.Collections.Generic;
using Uyflix.Domain.Entities;

namespace Uyflix.IDataAccess
{
    public interface IMoviesManagment
    {
        IEnumerable<Movie> GetMovies(Func<Movie, bool> filter);
        IEnumerable<Movie> GetMovies();
        void InsertMovie(Movie movie);
        Movie GetMovieById(int id);
        void DeleteMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void Save();
    }
}
