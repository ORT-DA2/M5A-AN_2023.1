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
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserLogic logic;
        public UserController(IUserLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(logic.GetAll());
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            try
            {
                return Ok(logic.LogIn(loginModel.Nickname, loginModel.Password));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [ServiceFilter(typeof(AuthorizationFilter))]
        [HttpGet("logout")]
        public IActionResult Logout([FromHeader] string token)
        {
            try
            {
                logic.LogOut(token);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
