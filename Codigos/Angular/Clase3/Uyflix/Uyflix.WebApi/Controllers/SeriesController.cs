using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Uyflix.Domain;
using Uyflix.Exceptions;
using Uyflix.IBusinessLogic;

namespace Uyflix.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SeriesController : Controller
    {
        private readonly ISeriesService seriesService;
        public SeriesController(ISeriesService seriesService)
        {
            this.seriesService = seriesService;
        }

        [HttpGet]
        public IActionResult GetSeries()
        {
            try
            {
                return Ok(seriesService.GetSeries());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetSeriesById([FromRoute] int id)
        {
            try
            {
                return Ok(seriesService.GetSeriesById(id));
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
        public IActionResult PostSeries([FromBody] Series movie)
        {
            try
            {
                return Ok(seriesService.InsertSeries(movie));
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
        public IActionResult PutSeries([FromRoute] int id, [FromBody] Series movie)
        {
            try
            {
                movie.Id = id;
                return Ok(seriesService.UpdateSeries(movie));
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
        public IActionResult DeleteSeries([FromRoute] int id)
        {
            try
            {
                seriesService.DeleteSeries(id);
                return Ok();
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
    }
}
