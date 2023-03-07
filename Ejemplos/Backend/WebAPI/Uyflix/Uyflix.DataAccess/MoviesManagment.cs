using System;
using System.Collections.Generic;
using Uyflix.Domain.Entities;
using Uyflix.IDataAccess;

namespace Uyflix.DataAccess
{
    public class MoviesManagment : IMoviesManagment
    {
        //----Este código simula el acceso a datos
        private List<Movie> movies;
        public MoviesManagment()
        {
            movies = new List<Movie>();
            ChargeMovies();
        } 
        private void ChargeMovies()
        {
            movies.Add(new Movie()
            {
                Id = 1,
                Category = "Animada",
                Country = "Estados Unidos",
                Director = "Chris Wedge y Carlos Saldanha",
                Name = "La Era de Hielo",
                Rating = 5,
                Year = 2002
            });
            movies.Add(new Movie()
            {
                Id = 2,
                Category = "Terror",
                Country = "Estados Unidos",
                Director = "Gore Verbinski",
                Name = "El Aro",
                Rating = 4,
                Year = 2002
            });
            movies.Add(new Movie()
            {
                Id = 3,
                Category = "Acción",
                Country = "Estados Unidos",
                Director = "Rob Cohen",
                Name = "Rapido y Furioso",
                Rating = 3,
                Year = 2001
            });
            movies.Add(new Movie()
            {
                Id = 4,
                Category = "Suspenso",
                Country = "Estados Unidos",
                Director = "Todd Phillips",
                Name = "Joker",
                Rating = 4,
                Year = 2019
            });
            movies.Add(new Movie()
            {
                Id = 1,
                Category = "Suspenso",
                Country = "España",
                Director = "Lluís Quílez",
                Name = "Bajocero",
                Rating = 2,
                Year = 2021
            });
        }
        //----

        public void DeleteMovie(Movie movie)
        {
            //Se elimina la pelicula de la base de datos
        }

        public Movie GetMovieById(int id)
        {
            return movies.Find(x => x.Id == id);
        }

        public IEnumerable<Movie> GetMovies(Predicate<Movie> filter)
        {
            return movies.FindAll(filter);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return movies;
        }

        public void InsertMovie(Movie movie)
        {
            //Agrega una pelicula a la base de datos
        }

        public void UpdateMovie(Movie movie)
        {
            //Actualiza la pelicula de la base de datos
        }
    }
}
