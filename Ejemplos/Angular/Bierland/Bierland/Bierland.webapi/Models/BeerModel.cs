using Bierland.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bierland.webapi.Models
{
    public class BeerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Qualification { get; set; }
        public int BeerFactoryId { get; set; }
        public Beer ToEntity() => new Beer()
        {
            Name = this.Name,
            Description = this.Description,
            Qualification = this.Qualification
        };
    }
}
