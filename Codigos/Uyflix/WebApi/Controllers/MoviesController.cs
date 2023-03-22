using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IBusinessLogic;
using Exceptions;
using Domain;
using WebApi.DTOs;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : Controller
    {
        private readonly IMoviesService moviesService;
        public MoviesController(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Movie>), 200)]
        [ProducesResponseType(typeof(MessageResponseDTO), 500)]
        public IActionResult GetMovies()
        {
            MessageResponseDTO response = new MessageResponseDTO(true, "");
            try
            {
                return Ok(moviesService.GetMovies());
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "Algo salió mal.";
                return StatusCode(500, response);
            }

        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Movie), 200)]
        [ProducesResponseType(typeof(MessageResponseDTO), 404)]
        [ProducesResponseType(typeof(MessageResponseDTO), 500)]
        public IActionResult GetMovieById([FromRoute] int id)
        {
            MessageResponseDTO response = new MessageResponseDTO(true, "");
            try
            {
                return Ok(moviesService.GetMovieById(id));
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

        [HttpPost]
        [ProducesResponseType(typeof(Movie), 200)]
        [ProducesResponseType(typeof(MessageResponseDTO), 400)]
        [ProducesResponseType(typeof(MessageResponseDTO), 500)]
        public IActionResult PostMovie([FromBody] CreateMovieRequestDTO movieDTO)
        {
            MessageResponseDTO response = new MessageResponseDTO(true, "");
            try
            {
                return Ok(moviesService.InsertMovie(movieDTO.TransformToMovie()));
            }
            catch (BusinessLogicException exception)
            {
                response.Success = false;
                response.Message = exception.Message;
                return BadRequest(response);
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "Algo salió mal.";
                return StatusCode(500, response);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Movie), 200)]
        [ProducesResponseType(typeof(MessageResponseDTO), 400)]
        [ProducesResponseType(typeof(MessageResponseDTO), 404)]
        [ProducesResponseType(typeof(MessageResponseDTO), 500)]
        public IActionResult PutMovie([FromRoute] int id, [FromBody] Movie movie)
        {
            MessageResponseDTO response = new MessageResponseDTO(true, "");
            try
            {
                movie.Id = id;
                return Ok(moviesService.UpdateMovie(movie));
            }
            catch (BusinessLogicException exception)
            {
                response.Success = false;
                response.Message = exception.Message;
                return BadRequest(response);
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

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(MessageResponseDTO), 200)]
        [ProducesResponseType(typeof(MessageResponseDTO), 404)]
        [ProducesResponseType(typeof(MessageResponseDTO), 500)]
        public IActionResult DeleteMovie([FromRoute] int id)
        {
            MessageResponseDTO response = new MessageResponseDTO(true, "");
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

