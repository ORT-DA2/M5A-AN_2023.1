using System;
using Microsoft.AspNetCore.Mvc;
using Uyflix.Domain.Entities;
using Uyflix.IBusiness;

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
        public IActionResult GetMovies([FromQuery] Movie movieFilter)
        {
            try
            {
                return Ok(moviesService.GetMovies(movieFilter));
            }
            catch (Exception)
            {
                return StatusCode(500, "Algo salió mal.");
            }

        }

        [HttpPost]
        public IActionResult PostMovie([FromBody] Movie movie)
        {
            try
            {
                return Ok(moviesService.InsertMovie(movie));
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Algo salió mal.");
            }
        }

        [HttpPut("{id}")] 
        public IActionResult PutMovie([FromRoute] int id, [FromBody] Movie movie)
        {
            try
            {
                movie.Id = id;
                return Ok(moviesService.UpdateMovie(movie));
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (NullReferenceException exception)
            {
                return NotFound(exception.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Algo salió mal.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie([FromRoute] int id)
        {
            try
            {
                moviesService.DeleteMovie(id);
                return Ok();
            }
            catch(ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (NullReferenceException exception)
            {
                return NotFound(exception.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Algo salió mal.");
            }
        }
    }
}
