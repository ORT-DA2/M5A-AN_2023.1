using Bierland.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bierland.webapi.Models
{
    public class PubModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Pub ToEntity() => new Pub()
        {
            Name = this.Name,
            Address = this.Address
        };
    }
}
