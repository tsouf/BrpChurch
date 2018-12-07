using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BRPChurch.Models
{
    public class Picture
    {
        [Key]
        public int Id { get; set; }
        public string description { get; set; }
        public string title { get; set; }
        public string email { get; set; }
        public string path { get; set; }
        public DateTime date { get; set; }
    }
}
