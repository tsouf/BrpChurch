using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BRPChurch.Models
{
    public partial class Activities
    {
        public Activities()
        {
            ActivityTag = new HashSet<ActivityTag>();
        }

        public int ActivityId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        [DisplayName("Activity Type")]
        public ICollection<ActivityTag> ActivityTag { get; set; }
    }
}
