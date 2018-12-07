using System;
using System.Collections.Generic;

namespace BRPChurch.Models
{
    public partial class Events
    {
        public int EventId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Venue { get; set; }
    }
}
