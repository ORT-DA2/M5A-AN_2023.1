using System;
using System.Collections.Generic;

namespace Bierland.domain
{
    public class Purchase
    {
        public int Id { get; set; }
        public virtual Pub Pub { get; set; }
        public virtual Beer Beer { get; set; }
        public virtual User User { get; set; }
        public int Count { get; set; }
        public DateTime Date { get; set; }
        public virtual List<BeerPurchase> BeerPurchases { get; set; }
    }
}
