using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BRPChurch.Models
{
    public partial class Members
    {
        public int MemberId { get; set; }
        [DisplayName("Full Name")]
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        [DisplayName("Postal Code")]
        public int PostNo { get; set; }
        public string Email { get; set; }
        [DisplayName("Phone Number")]
        public int PhoneNo { get; set; }
        public string UserId { get; set; }

        public AspNetUsers User { get; set; }

    }
}
