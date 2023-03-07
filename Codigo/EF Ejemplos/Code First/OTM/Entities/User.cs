using System;
using System.Collections.Generic;
using System.Text;

namespace OTM.Entities
{
    public class User
    {
        public User()
        {
            Documents = new HashSet<Document>();
        }

        public int Id { get; set; }

        public string UserName { get; set; }

        public ICollection<Document> Documents { get; set; }
    }
}
