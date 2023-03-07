using System.Collections.Generic;

namespace MTM.Entities
{
    public class Document
    {
        public Document()
        {
            UserDocuments = new HashSet<UserDocument>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<UserDocument> UserDocuments { get; set; }
    }
}
