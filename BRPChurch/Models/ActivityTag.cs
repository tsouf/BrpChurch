using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BRPChurch.Models
{
    public partial class ActivityTag
    {
        public int TagId { get; set; }
        [DisplayName("Activity")]
        public int ActivityId { get; set; }
        [DisplayName("Activity Type")]
        public int ActivityTypeId { get; set; }

        public Activities Activity { get; set; }
        public ActivityType ActivityType { get; set; }
    }
}
