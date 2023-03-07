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
    public class DocumentariesController : Controller
    {
        private readonly IDocumentariesService documentariesService;
        public DocumentariesController(IDocumentariesService documentarysService)
        {
            this.documentariesService = documentarysService;
        }

        [HttpGet]
        public IActionResult GetDocumentaries()
        {
            try
            {
                return Ok(documentariesService.GetDocumentaries());
            }
            catch (Exception)
            {
                return StatusCode(500, "Algo salió mal.");
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetDocumentaryById([FromRoute] int id)
        {
            try
            {
                return Ok(documentariesService.GetDocumentaryById(id));
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
        public IActionResult PostDocumentary([FromBody] Documentary movie)
        {
            try
            {
                return Ok(documentariesService.InsertDocumentary(movie));
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
        public IActionResult PutDocumentary([FromRoute] int id, [FromBody] Documentary movie)
        {
            try
            {
                movie.Id = id;
                return Ok(documentariesService.UpdateDocumentary(movie));
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
        public IActionResult DeleteDocumentary([FromRoute] int id)
        {
            try
            {
                documentariesService.DeleteDocumentary(id);
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
