using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bierland.businesslogicInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bierland.domain;
using Bierland.webapi.Models;
using Bierland.webapi.Filters;

namespace Bierland.webapi.Controllers
{
    [ApiController]
    //[ServiceFilter(typeof(AuthorizationFilter))]
    [Route("[controller]")]
    public class BeerController : ControllerBase
    {
        private readonly IBeerLogic logic;
        public BeerController(IBeerLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IActionResult Get([FromHeader] string token)
        {
            IEnumerable<Beer> beer = logic.GetAll();
            return Ok(beer);
        }
        [HttpPost]
        public IActionResult Post(BeerModel beer)
        {
            Beer newBeer = logic.Add(beer.ToEntity(), beer.BeerFactoryId);
            return Ok(newBeer);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BeerModel beerModel)
        {
            try
            {
                Beer beer = beerModel.ToEntity();
                beer.Id = id;
                logic.Update(beer);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            logic.Delete(id);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Beer beer = logic.GetById(id);
                return Ok(beer);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
