using System;
using System.Collections.Generic;
using System.Text;

namespace Bierland.domain
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public virtual List<Purchase> Purchases { get; set; }
    }
}
