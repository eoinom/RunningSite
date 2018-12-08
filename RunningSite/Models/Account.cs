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
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public Country Country { get; set; }

        [Required]
        public GenderEnum Gender { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        public bool NewsletterSub { get; set; }
    }
}