using System;
using Microsoft.AspNetCore.Mvc;
using Uyflix.Domain.Entities;
using Uyflix.IBusiness;
using Uyflix.Webapi.Filters;

namespace Uyflix.Webapi.Controllers
{
    [ApiController]
    [ExceptionFilter]
    [ResultFilter]
    [AuthorizationFitler]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService moviesService;
        public MoviesController(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }

        [HttpGet]
        public IActionResult GetMovies([FromQuery] Movie movieFilter)
        {
            return Ok(moviesService.GetMovies(movieFilter));
        }

        [HttpPost]
        public IActionResult PostMovie([FromBody] Movie movie)
        {
            return Ok(moviesService.InsertMovie(movie));
        }

        [HttpPut("{id}")]
        public IActionResult PutMovie([FromRoute] int id, [FromBody] Movie movie)
        {
            movie.Id = id;
            return Ok(moviesService.UpdateMovie(movie));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie([FromRoute] int id)
        {
            moviesService.DeleteMovie(id);
            return Ok();
        }
    }
}
