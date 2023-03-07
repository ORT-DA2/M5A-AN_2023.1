using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bierland.businesslogicInterface;
using Bierland.domain;
using Bierland.webapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bierland.webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BeerFactoryController : ControllerBase
    {
        private readonly IBeerFactoryLogic logic;
        public BeerFactoryController(IBeerFactoryLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<BeerFactory> beerFactories = logic.GetAll();
            return Ok(beerFactories);
        }
        [HttpPost]
        public IActionResult Post(BeerFactoryModel beerFactory)
        {
            BeerFactory newBeerFactory = logic.Add(beerFactory.ToEntity());
            return Ok(newBeerFactory);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BeerFactoryModel beerFactoryModel)
        {
            try
            {
                BeerFactory beerFactory = beerFactoryModel.ToEntity();
                beerFactory.Id = id;
                logic.Update(beerFactory);
                return Ok();
            }
            catch(Exception e)
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
                BeerFactory beerFactory = logic.GetById(id);
                return Ok(beerFactory);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
