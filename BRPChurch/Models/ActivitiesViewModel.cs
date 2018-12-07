using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BRPChurch.Models
{
    public partial class ActivitiesViewModel
    {
        public ActivitiesViewModel()
        {
            ActivityTag = new HashSet<ActivityTag>();
        }

        public int ActivityId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        [DisplayName("Type")]
        public int Tag { get; set; }
        [DisplayName("Type")]
        public string ActivityType { get; set; }
        public ICollection<ActivityTag> ActivityTag { get; set; }
    }
}
