using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyStore.API.Data;
using MyStore.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductManager manager;
        public ProductsController(DbContext context)
        {
            manager = new ProductManager(context);
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(manager.GetProducts());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(manager.GetProduct(id));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            manager.DeleteProduct(id);
            return Ok();
        }
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            manager.CreateProduct(product);
            return Ok();
        }
    }
}
