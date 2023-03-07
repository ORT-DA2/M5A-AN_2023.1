using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uyflix.Webapi.DTOs
{
    public class ResponseDTO
    {
        public object Content { get; set; }
        public bool IsSuccess { get; set; }
        public int Code { get; set; }
        public string ErrorMessage { get; set; }
    }
}
