using System;
using System.Collections.Generic;
using Uyflix.Domain;

namespace Uyflix.IDataAccess
{
    public interface IMoviesManagement
    {
        IEnumerable<Movie> GetMovies();
        void InsertMovie(Movie movie);
        Movie GetMovieById(int id);
        void DeleteMovie(Movie movie);
        void UpdateMovie(Movie movie);
    }
}
