using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BRPChurch.Models
{
    public partial class DateRange
    {   [DataType(DataType.Date)]
        public DateTime start { get; set; }
       [DataType(DataType.Date)]
        public DateTime end { get; set; }
    }
}
