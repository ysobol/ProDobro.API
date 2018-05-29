using System;
using System.Collections.Generic;

namespace ProDobro.API.Models
{
    public partial class Ssotypes
    {
        public Ssotypes()
        {
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Users> Users { get; set; }
    }
}
