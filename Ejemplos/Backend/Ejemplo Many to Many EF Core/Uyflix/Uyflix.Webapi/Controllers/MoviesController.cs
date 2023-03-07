using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Uyflix.IBusiness;
using Uyflix.Domain.Models;

namespace Uyflix.Webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }
        [HttpGet]
        public IActionResult GetAllMovies()
        {
            return Ok(moviesService.GetAllMovies().Select(m => new MovieModel(m)));
        }
        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            return Ok(new MovieModel(moviesService.GetMovieById(id)));
        }
        [HttpPost]
        public IActionResult PostMovie([FromBody] MovieModel movie)
        {
            int id = moviesService.InsertMovie(movie.ToEntity());
            return Ok($"Se insertó una pelicula con id: {id}");
        }
        [HttpPost("{idMovie}/Categories/{idCategory}")]
        public IActionResult PostCategoryToMovie(int idMovie, int idCategory)
        {
            moviesService.AddCategoryToMovie(idMovie, idCategory);
            return Ok();
        }
        [HttpPost("{idMovie}/Actors/{idActor}")]
        public IActionResult PostActorToMovie(int idMovie, int idActor)
        {
            moviesService.AddActorToMovie(idMovie, idActor);
            return Ok();
        }
    }
}
