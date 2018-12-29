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
        [Required(ErrorMessage = "Must enter an Email Address")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Must enter a password")]
        [DataType(DataType.Password)]
        [StringLength(18, ErrorMessage = "Password must be 6 to 18 characters long", MinimumLength = 6)]
        public string Password { get; set; }
        
        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        
        [Required(ErrorMessage = "Must enter a First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Must enter a Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Must enter a Country")]
        //public Country Country { get; set; }
        public string Country { get; set; }

        [Required(ErrorMessage = "Must select a Gender")]
        public GenderEnum Gender { get; set; }

        [Required(ErrorMessage = "Must enter a Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        public bool NewsletterSub { get; set; }
    }
}