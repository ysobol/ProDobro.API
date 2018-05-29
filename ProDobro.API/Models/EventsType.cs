using System;
using System.Collections.Generic;

namespace ProDobro.API.Models
{
    public partial class EventsType
    {
        public EventsType()
        {
            Events = new HashSet<Events>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Events> Events { get; set; }
    }
}
