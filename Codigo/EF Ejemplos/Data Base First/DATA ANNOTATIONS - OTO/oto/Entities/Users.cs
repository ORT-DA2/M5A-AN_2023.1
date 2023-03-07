using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oto.Entities
{
    public partial class Users
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public int DocumentId { get; set; }

        [InverseProperty("User")]
        public virtual Documents Documents { get; set; }
    }
}
