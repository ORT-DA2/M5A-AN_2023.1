using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Uyflix.Webapi.DTOs;

namespace Uyflix.Webapi.Filters
{
    public class ExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            int statusCode = 500;
            /*
                Ustedes podrian tener definida una lista de codigos
                para indicar la response independiente de los statusCode.
                Por ejemplo:
                
                1000 => cuando todo ocurre bien.
                2002 => cuando algo sale mal y no se identifico.
                2003 => cuando no se encuentra algo.
                2004 => cuando faltan argumentos.

                Si bien en este caso son iguales a los statusCode de la resonse,
                podrian tener una granularidad mayor y ser especificos por error y entidad.

                Lo ideal seria que este codigo lo tengan en la excepción que utilicen, por eso
                es buena práctica manjear sus propias excepciones.
             */
            ResponseDTO response = new ResponseDTO()
            {
                Code = 2002,
                IsSuccess = false,
                ErrorMessage = context.Exception.Message
            };

            if (context.Exception is NullReferenceException)
            {
                statusCode = 404;
                response.Code = 2003;
            }
            if (context.Exception is ArgumentException)
            {
                statusCode = 400;
                response.Code = 2004;
            }

            context.Result = new ObjectResult(response)
            {
                StatusCode = statusCode
            };
        }
    }
}
