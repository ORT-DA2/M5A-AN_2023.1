using System;
using System.Collections.Generic;

namespace Bierland.domain
{
    public class UserSession
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public virtual User User { get; set; }
        public DateTime ConnectedAt { get; set; }
        public UserSession()
        {
            ConnectedAt = DateTime.Now;
        }
    }
}
