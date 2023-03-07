using System;
using System.Collections.Generic;
using System.Text;

namespace Bierland.domain
{
    public class BeerPurchase
    {
        public int BeerId { get; set; }
        public virtual Beer Beer { get; set; }
        public int PurchaseId { get; set; }
        public virtual Purchase Purchase { get; set; }
    }
}
