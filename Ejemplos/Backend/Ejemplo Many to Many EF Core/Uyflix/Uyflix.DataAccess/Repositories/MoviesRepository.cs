using Microsoft.EntityFrameworkCore;
using System.Linq;
using Uyflix.Domain.Entities;
using Uyflix.IDataAccess;

namespace Uyflix.DataAccess.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly DbSet<Movie> movies;
        private readonly DbContext context;
        public MoviesRepository(DbContext context)
        {
            movies = context.Set<Movie>();
            this.context = context;
        }
        public IQueryable<Movie> GetAllMovies()
        {
            return movies.Include(m => m.MoviesCategories).ThenInclude(c => c.Category).Include(m => m.Starring);
        }
        public void InsertMovie(Movie movie)
        {
            // Aca preveo que si recibo un id es porque ya existe
            // de lo contrario lanza excepción
            foreach(Actor actor in movie.Starring)
            {
                if (actor.Id != 0)
                    context.Attach(actor);
            }
            foreach(MovieCategory category in movie.MoviesCategories)
            {
                if (category.CategoryId != 0)
                    context.Attach(category);
            }
            //En caso que sean 0 se crea tanto la Movie como las Categories y Actors
            movies.Add(movie);
        }
        public Movie GetMovieById(int id)
        {
            return movies.Include(m => m.MoviesCategories).
                ThenInclude(c => c.Category).
                Include(m => m.Starring).
                Where(m => m.Id == id).FirstOrDefault();
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateMovie(Movie movie)
        {
            movies.Update(movie);
        }
    }
}
