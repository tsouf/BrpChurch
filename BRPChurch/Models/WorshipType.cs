using System;
using System.Collections.Generic;

namespace BRPChurch.Models
{
    public partial class WorshipType
    {
        public WorshipType()
        {
            Worship = new HashSet<Worship>();
        }

        public int WorshipTypeId { get; set; }
        public string Type { get; set; }

        public ICollection<Worship> Worship { get; set; }
    }
}
