using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BRPChurch.Models
{
    public partial class ActivityType
    {
        public ActivityType()
        {
            ActivityTag = new HashSet<ActivityTag>();
        }

        public int ActivityTypeId { get; set; }
        public string Name { get; set; }
        [DisplayName("Activity Type")]
        public ICollection<ActivityTag> ActivityTag { get; set; }
    }
}
