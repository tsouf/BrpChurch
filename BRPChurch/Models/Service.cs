using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BRPChurch.Models
{
    public partial class Service
    {
        public Service()
        {
            ServiceWorship = new HashSet<ServiceWorship>();
        }

        public int ServiceId { get; set; }
        public string Leader { get; set; }
        public string Speaker { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public ICollection<ServiceWorship> ServiceWorship { get; set; }
    }
}
