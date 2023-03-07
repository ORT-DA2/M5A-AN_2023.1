using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTM.Entities
{
    public partial class Documents
    {
        public Documents()
        {
            UserDocuments = new HashSet<UserDocuments>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [InverseProperty("Document")]
        public virtual ICollection<UserDocuments> UserDocuments { get; set; }
    }
}
