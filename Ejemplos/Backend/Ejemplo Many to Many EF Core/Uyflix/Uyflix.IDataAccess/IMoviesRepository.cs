using System;
using System.Linq;
using Uyflix.Domain.Entities;

namespace Uyflix.IDataAccess
{
    public interface IMoviesRepository
    {
        IQueryable<Movie> GetAllMovies();
        void InsertMovie(Movie movie);
        Movie GetMovieById(int id);
        void UpdateMovie(Movie movie);
        void Save();
    }
}
