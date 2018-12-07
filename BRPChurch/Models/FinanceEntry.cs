using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BRPChurch.Models
{
    public partial class FinanceEntry
    {
        public int FinanceEntryId { get; set; }
        public int FinanceTypeId { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public double Amount { get; set; }

        [DisplayName("Type")]
        public FinanceType FinanceType { get; set; }
    }
}
