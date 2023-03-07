using System;
using System.Collections.Generic;
using System.Linq;
using Uyflix.Domain.Entities;
using Uyflix.IBusiness;
using Uyflix.IDataAccess;

namespace Uyflix.Business
{
    public class MoviesService : IMoviesService
    {
        private readonly IMoviesRepository moviesRepository;
        private readonly ICategoriesRepository categoriesRepository;
        private readonly IActorsRepository actorsRepository;

        public MoviesService(IMoviesRepository moviesRepository, ICategoriesRepository categoriesRepository,
            IActorsRepository actorsRepository)
        {
            this.moviesRepository = moviesRepository;
            this.categoriesRepository = categoriesRepository;
            this.actorsRepository = actorsRepository;
        }

        public void AddActorToMovie(int movieId, int actorId)
        {
            Movie movie = moviesRepository.GetMovieById(movieId);
            Actor actor = actorsRepository.GetActorById(actorId);

            movie.Starring.Add(actor);
            moviesRepository.UpdateMovie(movie);
            moviesRepository.Save();
        }

        public void AddCategoryToMovie(int movieId, int categoryId)
        {
            Movie movie = moviesRepository.GetMovieById(movieId);
            Category category = categoriesRepository.GetCategoryById(categoryId);

            MovieCategory categoryToAdd = new MovieCategory
            {
                Category = category,
                CategoryId = categoryId,
                Movie = movie,
                MovieId = movie.Id
            };

            movie.MoviesCategories.Add(categoryToAdd);
            moviesRepository.UpdateMovie(movie);
            moviesRepository.Save();
        }

        public IQueryable<Movie> GetAllMovies()
        {
            return moviesRepository.GetAllMovies();
        }

        public Movie GetMovieById(int id)
        {
            return moviesRepository.GetMovieById(id);
        }

        public int InsertMovie(Movie movie)
        {
            moviesRepository.InsertMovie(movie);
            moviesRepository.Save();
            return movie.Id;
        }
    }
}
