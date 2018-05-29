using System;
using System.Collections.Generic;

namespace ProDobro.API.Models
{
    public partial class Calendar
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public DateTime Date { get; set; }

        public Events Event { get; set; }
    }
}
