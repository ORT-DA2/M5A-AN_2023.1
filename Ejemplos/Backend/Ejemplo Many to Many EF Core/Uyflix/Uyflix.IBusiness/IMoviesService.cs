using System;
using System.Collections.Generic;
using System.Linq;
using Uyflix.Domain.Entities;

namespace Uyflix.IBusiness
{
    public interface IMoviesService
    {
        IQueryable<Movie> GetAllMovies();
        Movie GetMovieById(int id);
        int InsertMovie(Movie movie);
        void AddCategoryToMovie(int movieId, int categoryId);
        void AddActorToMovie(int movieId, int actorId);
    }
}
