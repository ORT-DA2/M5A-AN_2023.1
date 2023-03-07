using System;
using System.Collections.Generic;

namespace Bierland.domain
{
    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Qualification { get; set; }
        public virtual List<BeerPurchase> BeerPurchases { get; set; }
        public virtual List<BeerPubs> BeerPubs { get; set; }
        public bool IsDeleted { get; set; }
    }
}
