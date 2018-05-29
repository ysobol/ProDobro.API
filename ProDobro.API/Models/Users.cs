using System;
using System.Collections.Generic;

namespace ProDobro.API.Models
{
    public partial class Users
    {
        public Users()
        {
            Events = new HashSet<Events>();
        }

        public int Id { get; set; }
        public int TypeId { get; set; }
        public int SsotypeId { get; set; }
        public string Ssokey { get; set; }

        public Ssotypes Ssotype { get; set; }
        public UsersTypes Type { get; set; }
        public ICollection<Events> Events { get; set; }
    }
}
