using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BRPChurch.Models
{
    public partial class ServiceWorship
    {
        public int ServiceWorshipId { get; set; }
        [DisplayName("Song")]
        public int WorshipId { get; set; }
        [DisplayName("Date")]
        public int ServiceId { get; set; }

        public Service Service { get; set; }
        public Worship Worship { get; set; }
    }
}
