using System;
using System.Collections.Generic;
using System.Text;

namespace Bierland.domain
{
    public class BeerPubs
    {
        public int BeerId { get; set; }
        public virtual Beer Beer { get; set; }
        public int PubId { get; set; }
        public virtual Pub Pub { get; set; }
    }
}
