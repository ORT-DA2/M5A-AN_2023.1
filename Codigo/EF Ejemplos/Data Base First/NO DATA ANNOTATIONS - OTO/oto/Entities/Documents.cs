using System;
using System.Collections.Generic;

namespace oto.Entities
{
    public partial class Documents
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }

        public virtual Users User { get; set; }
    }
}
