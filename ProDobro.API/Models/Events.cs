using System;
using System.Collections.Generic;

namespace ProDobro.API.Models
{
    public partial class Events
    {
        public Events()
        {
            Calendar = new HashSet<Calendar>();
        }

        public int Id { get; set; }
        public int TypeId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }

        public EventsType Type { get; set; }
        public Users User { get; set; }
        public ICollection<Calendar> Calendar { get; set; }
    }
}
