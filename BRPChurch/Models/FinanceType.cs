using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BRPChurch.Models
{
    public partial class FinanceType
    {
        public FinanceType()
        {
            FinanceEntry = new HashSet<FinanceEntry>();
        }

        public int FinanceTypeId { get; set; }
        public string Title { get; set; }
        [DisplayName("Income")]
        public bool Type { get; set; }

        public ICollection<FinanceEntry> FinanceEntry { get; set; }
    }
}
