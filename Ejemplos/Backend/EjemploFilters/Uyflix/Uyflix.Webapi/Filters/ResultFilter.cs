using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uyflix.Webapi.DTOs;

namespace Uyflix.Webapi.Filters
{
    public class ResultFilter : Attribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            ResponseDTO response = new ResponseDTO
            {
                Code = 1000,
                Content = ((ObjectResult)context.Result).Value,
                IsSuccess = true
            };

            context.Result = new ObjectResult(response)
            {
                StatusCode = 200
            };
        }
    }
}
