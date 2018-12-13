using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using RunningSite.Utils;

namespace RunningSite.Models
{
    public class Account
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(18, ErrorMessage = "Password must be 6 to 18 characters long", MinimumLength = 6)]
        public string Password { get; set; }
        
        [Required]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        //public Country Country { get; set; }
        public string Country { get; set; }

        [Required]
        public GenderEnum Gender { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        public bool NewsletterSub { get; set; }

        [Display(Name = "Account Type")]
        public RoleEnum AccountRole { get; set; }
    }
}