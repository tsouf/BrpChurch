using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BRPChurch.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [DisplayName("Full Name")]
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        [DisplayName("Postal Code")]
        public int PostNo { get; set; }
        [DisplayName("Phone Number")]
        public int PhoneNo { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
        [DisplayName("Hidden Account")]
        public bool Private { get; set; }
    }
}
