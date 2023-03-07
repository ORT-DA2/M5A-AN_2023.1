using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bierland.businesslogicInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bierland.domain;
using Bierland.webapi.Models;

namespace Bierland.webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PubController : ControllerBase
    {
        private readonly IPubLogic logic;
        public PubController(IPubLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<PubModel> pubs = logic.GetAll().Select(
                x => new PubModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address
                });
            return Ok(pubs);
        }
        [HttpPost]
        public IActionResult Post(PubModel pub)
        {
            Pub newPub = logic.Add(pub.ToEntity());
            return Ok(newPub);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PubModel pubModel)
        {
            try
            {
                Pub pub = pubModel.ToEntity();
                pub.Id = id;
                logic.Update(pub);
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
                Pub pub = logic.GetById(id);
                return Ok(pub);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPut("/Beer")]
        public IActionResult PutBeer([FromBody] BeerPubModel beerPub)
        {
            try
            {
                logic.AddBeer(beerPub.PubId, beerPub.BeerId);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
