using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTM.Entities
{
    public partial class Users
    {
        public Users()
        {
            UserDocuments = new HashSet<UserDocuments>();
        }

        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<UserDocuments> UserDocuments { get; set; }
    }
}
