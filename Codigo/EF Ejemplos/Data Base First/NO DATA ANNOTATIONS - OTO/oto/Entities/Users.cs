using System;
using System.Collections.Generic;

namespace oto.Entities
{
    public partial class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int DocumentId { get; set; }

        public virtual Documents Documents { get; set; }
    }
}
