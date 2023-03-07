using Bierland.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bierland.webapi.Models
{
    public class BeerFactoryModel
    {
        public string Name { get; set; }
        public string Nationality { get; set; }
        public BeerFactory ToEntity() => new BeerFactory()
        {
            Name = this.Name,
            Nationality = this.Nationality
        };
    }
}
