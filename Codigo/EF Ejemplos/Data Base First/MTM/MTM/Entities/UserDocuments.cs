using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTM.Entities
{
    public partial class UserDocuments
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DocumentId { get; set; }

        [ForeignKey(nameof(DocumentId))]
        [InverseProperty(nameof(Documents.UserDocuments))]
        public virtual Documents Document { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Users.UserDocuments))]
        public virtual Users User { get; set; }
    }
}
