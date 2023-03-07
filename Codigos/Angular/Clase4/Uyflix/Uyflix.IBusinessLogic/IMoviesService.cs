using System;
using System.Collections.Generic;
using Uyflix.Domain;

namespace Uyflix.IBusinessLogic
{
    public interface IMoviesService
    {
        IEnumerable<Movie> GetMovies();
        Movie GetMovieById(int id);
        Movie InsertMovie(Movie movie);
        Movie UpdateMovie(Movie movie);
        void DeleteMovie(int id);
    }
}
