using System.Collections.Generic;
using Uyflix.Domain;
using Uyflix.IDataAccess;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Uyflix.DataAccess
{
    public class MoviesManagement: IMoviesManagement
    {
        private UyflixContext UyflixContext { get; set; }
        public MoviesManagement(UyflixContext uyflixContext)
        {
            this.UyflixContext = uyflixContext;
        }

        public IEnumerable<Movie> GetMovies()
        {
            return UyflixContext.Movies.ToList();
        }

        public void InsertMovie(Movie movie)
        {
            UyflixContext.Movies.Add(movie);
            UyflixContext.SaveChanges();
        }

        public Movie GetMovieById(int id)
        {
            return UyflixContext.Movies.Where<Movie>(movie => movie.Id == id).AsNoTracking().FirstOrDefault();
        }

        public void DeleteMovie(Movie movieToDelete)
        {
            UyflixContext.Movies.Remove(movieToDelete);
            UyflixContext.SaveChanges();
        }

        public void UpdateMovie(Movie movieToUpdate)
        {
            UyflixContext.Movies.Attach(movieToUpdate);
            UyflixContext.Entry(movieToUpdate).State = EntityState.Modified;
            UyflixContext.SaveChanges();
        }
    }
}
