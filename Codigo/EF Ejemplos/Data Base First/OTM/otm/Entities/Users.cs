using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace otm.Entities
{
    public partial class Users
    {
        public Users()
        {
            Documents = new HashSet<Documents>();
        }

        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Documents> Documents { get; set; }
    }
}
