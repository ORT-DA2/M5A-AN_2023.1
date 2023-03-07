using Bierland.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bierland.webapi.Models
{
    public class LoginModel
    {
        public string Nickname { get; set; }
        public string Password { get; set; }
    }
}
