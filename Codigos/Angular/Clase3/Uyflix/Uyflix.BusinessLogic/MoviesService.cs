using System;
using System.Collections.Generic;
using Uyflix.Domain;
using Uyflix.Exceptions;
using Uyflix.IBusinessLogic;
using Uyflix.IDataAccess;

namespace Uyflix.BusinessLogic
{
    public class MoviesService: IMoviesService
    {
        private readonly IMoviesManagement moviesManagement;
        public MoviesService(IMoviesManagement moviesManagement)
        {
            this.moviesManagement = moviesManagement;
        }

        public IEnumerable<Movie> GetMovies()
        {
            return moviesManagement.GetMovies();
        }

        public Movie GetMovieById(int id)
        {
            Movie movie = moviesManagement.GetMovieById(id);
            if (movie == null)
            {
                throw new NotFoundException("La película no existe");
            }
            return movie;
        }

        public Movie InsertMovie(Movie movie)
        {
            if (IsMovieValid(movie))
            {
                moviesManagement.InsertMovie(movie);
            }
            return movie;
        }

        public Movie UpdateMovie(Movie movieToUpdate)
        {
            if(IsMovieValid(movieToUpdate))
            {
                Movie movie = moviesManagement.GetMovieById(movieToUpdate.Id);
                if(movie == null)
                {
                    throw new NotFoundException("La película no existe");
                }
                moviesManagement.UpdateMovie(movieToUpdate);
            }
            return movieToUpdate;
        }

        public void DeleteMovie(int id)
        {
            Movie movieToDelete = moviesManagement.GetMovieById(id);
            if (movieToDelete == null)
            {
                throw new NotFoundException("La película no existe");
            }
            moviesManagement.DeleteMovie(movieToDelete);
        }

        private bool IsMovieValid(Movie movie)
        {
            if (movie == null)
            {
                throw new BusinessLogicException("Película inválida");
            }
            if (movie.Name == null || movie.Name == "")
            {
                throw new BusinessLogicException("Debe ingresar un nombre");
            }
            if (movie.Category == null || movie.Category == "")
            {
                throw new BusinessLogicException("Debe ingresar una categoría");
            }
            if (movie.Director == null || movie.Director == "")
            {
                throw new BusinessLogicException("Debe ingresar un director");
            }
            if (movie.Country == null || movie.Country == "")
            {
                throw new BusinessLogicException("Debe ingresar un país");
            }
            if (movie.Year <= 0)
            {
                throw new BusinessLogicException("Debe ingresar un año válido");
            }
            if (movie.Rating < 1)
            {
                throw new BusinessLogicException("El rating debe ser mayor o igual a 1");
            }

            if (movie.Rating > 5)
            {
                throw new BusinessLogicException("El rating debe ser menor o igual a 5");
            }
            return true;
        }
    }
}
