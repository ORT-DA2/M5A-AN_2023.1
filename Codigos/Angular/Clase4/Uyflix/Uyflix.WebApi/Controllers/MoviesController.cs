using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Uyflix.IBusinessLogic;
using Uyflix.Exceptions;
using Uyflix.Domain;
using Uyflix.WebApi.DTOs;

namespace Uyflix.WebApi.Controllers
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
        public IActionResult GetMovies()
        {
            try
            {
                return Ok(moviesService.GetMovies());
            }
            catch (Exception)
            {
                return StatusCode(500, "Algo salió mal.");
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById([FromRoute] int id)
        {
            try
            {
                return Ok(moviesService.GetMovieById(id));
            }
            catch (NotFoundException exception)
            {
                return NotFound(exception.Message);
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
            catch (BusinessLogicException exception)
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
            catch (BusinessLogicException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (NotFoundException exception)
            {
                return NotFound(exception.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie([FromRoute] int id)
        {
            DeleteResponseDto response = new DeleteResponseDto()
            {
                Success = true,
                Message = "",
            };
            try
            {
                moviesService.DeleteMovie(id);
                return Ok(response);
            }
            catch (NotFoundException exception)
            {
                response.Success = false;
                response.Message = exception.Message;
                return NotFound(response);
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "Algo salió mal.";
                return StatusCode(500, response);
            }
        }
    }
}
