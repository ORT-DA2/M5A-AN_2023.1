using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uyflix.Webapi.DTOs;

namespace Uyflix.Webapi.Filters
{
    public class AuthorizationFitler : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string token = context.HttpContext.Request.Headers["userToken"];
            
            if(token == null)
            {
                ResponseDTO response = new ResponseDTO
                {
                    Code = 3001,
                    ErrorMessage = "Debe ingresar un userToken en el Encabezado",
                    IsSuccess = false
                };
                context.Result = new ObjectResult(response)
                {
                    StatusCode = 401,
                };
            }

            if (IsValidToken(token))
            {
                ResponseDTO response = new ResponseDTO
                {
                    Code = 3002,
                    ErrorMessage = "El userToken ingresado no es correcto",
                    IsSuccess = false
                };
                context.Result = new ObjectResult(response)
                {
                    StatusCode = 403,
                };
            }
        }
        /*
            ESTE METODO DEBERIA IR EN SU CAPA LOGICA!!!
            Encapsulado la logica para autorizar usuarios en su sistema
            ESTE ES UN EJEMPLO SIN LOGICA!!
         */
        private bool IsValidToken(string token)
        {
            return token == "12345-qwerty-6789";
        }
    }
}
