using System;
using System.Collections.Generic;

namespace Bierland.domain
{
    public class BeerFactory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public bool IsDeleted { get; set; }
        public virtual List<Beer> Beers { get; set; }
    }
}
