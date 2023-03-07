using System;
using System.Collections.Generic;
using Uyflix.Domain.Entities;
using Uyflix.IBusiness;
using Uyflix.IDataAccess;

namespace Uyflix.Business
{
    public class MoviesService : IMoviesService
    {
        private readonly IMoviesManagment moviesManagment;
        public MoviesService(IMoviesManagment moviesManagment)
        {
            this.moviesManagment = moviesManagment;
        }
        public void DeleteMovie(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentException("El identificador debe ser mayor que 0.");
            }
            Movie movieToDelete = moviesManagment.GetMovieById(id);
            if(movieToDelete == null)
            {
                throw new NullReferenceException($"La pelicula de id: {id} no existe.");
            }
            moviesManagment.DeleteMovie(movieToDelete);
        }

        public IEnumerable<Movie> GetMovies(Movie movie = null)
        {
            if (movie.Name != null
                || movie.Year != 0
                || movie.Director != null
                || movie.Country != null
                || movie.Category != null)
            {
                Predicate<Movie> filter = new Predicate<Movie>(
                    x => x.Name == movie.Name
                    || x.Category == movie.Category
                    || x.Director == movie.Director
                    || x.Country == movie.Country
                    || x.Year == movie.Year);
                return moviesManagment.GetMovies(filter);
            }
            else
            {
                return moviesManagment.GetMovies();
            }
        }

        public Movie InsertMovie(Movie movie)
        {
            if(movie == null)
            {
                throw new ArgumentException("Debe enviar la pelicula.");
            }
            if (!movie.IsValid())
            {
                throw new ArgumentException("El formato de pelicula es incorrecto.");
            }
            if (movie.Rating > 5)
            {
                throw new ArgumentException("El rating de una pelicula debe ser entre 0 y 5");
            }
            moviesManagment.InsertMovie(movie);
            return movie;
        }

        public Movie UpdateMovie(Movie movie)
        {
            if(movie == null)
            {
                throw new ArgumentException("Debe enviar la pelicula.");
            }
            if (!movie.IsValid())
            {
                throw new ArgumentException("El formato de pelicula es incorrecto.");
            }
            if (movie.Rating > 5)
            {
                throw new ArgumentException("El rating de una pelicula debe ser entre 0 y 5");
            }
            Movie movieToUpdate = moviesManagment.GetMovieById(movie.Id);
            if (movieToUpdate == null)
            {
                throw new NullReferenceException($"La pelicula de id: {movie.Id} no existe.");
            }
            moviesManagment.UpdateMovie(movie);
            return movie;
        }
    }
}
