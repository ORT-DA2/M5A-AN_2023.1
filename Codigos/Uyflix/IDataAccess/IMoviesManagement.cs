using System;
using Domain;

namespace IDataAccess
{
    public interface IMoviesManagement
    {
        IEnumerable<Movie>? GetMovies();
        void InsertMovie(Movie movie);
        Movie? GetMovieById(int id);
        void DeleteMovie(Movie movie);
        void UpdateMovie(Movie movie);
    }
}

