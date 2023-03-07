using System;
using System.Collections.Generic;
using System.Text;

namespace MTM.Entities
{
    public class User
    {
        public User()
        {
            UserDocuments = new HashSet<UserDocument>();
        }

        public int Id { get; set; }

        public string UserName { get; set; }

        public virtual ICollection<UserDocument> UserDocuments { get; set; }
    }
}
