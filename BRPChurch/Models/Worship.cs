using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BRPChurch.Models
{
    public partial class Worship
    {
        public Worship()
        {
            ServiceWorship = new HashSet<ServiceWorship>();
        }

        public int WorshipId { get; set; }
        [DisplayName("Type")]
        public int WorshipTypeId { get; set; }
        public string Name { get; set; }
        [DisplayName("Song Number")]
        public string Text { get; set; }

        public WorshipType WorshipType { get; set; }
        public ICollection<ServiceWorship> ServiceWorship { get; set; }
    }
}
