using Bierland.businesslogicInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bierland.webapi.Filters
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        private readonly IUserLogic logic;
        public AuthorizationFilter(IUserLogic logic)
        {
            this.logic = logic;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string token = context.HttpContext.Request.Headers["token"];
            if (token == null)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content ="You aren't logued."
                };
                return;
            }
            if (!logic.IsLogued(token))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 403,
                    Content = "You aren't logued correctly."
                };
                return;
            }
        }
    }
}
