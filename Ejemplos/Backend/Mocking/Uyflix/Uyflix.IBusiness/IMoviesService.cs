using System;
using System.Collections.Generic;
using Uyflix.Domain.Entities;

namespace Uyflix.IBusiness
{
    public interface IMoviesService
    {
        IEnumerable<Movie> GetMovies(Movie movie = null);
        Movie InsertMovie(Movie movie);
        Movie UpdateMovie(Movie movie);
        void DeleteMovie(int id);
    }
}
