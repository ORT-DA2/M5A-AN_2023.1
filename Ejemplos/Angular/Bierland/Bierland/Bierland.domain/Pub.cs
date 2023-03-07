using System;
using System.Collections.Generic;

namespace Bierland.domain
{
    public class Pub
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual List<BeerPubs> BeerPubs { get; set; }
        public bool IsDeleted { get; set; }
    }
}
