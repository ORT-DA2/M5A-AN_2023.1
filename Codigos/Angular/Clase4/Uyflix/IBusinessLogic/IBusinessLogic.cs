using System;
using Domain;

namespace IBusinessLogic
{
    public interface IMoviesService
    {
        IEnumerable<Movie> GetMovies();
        Movie GetMovieById(int id);
        Movie? InsertMovie(Movie? movie);
        Movie? UpdateMovie(Movie? movie);
        void DeleteMovie(int id);
    }
}

