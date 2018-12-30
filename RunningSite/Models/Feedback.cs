using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RunningSite.Models
{
    public class Feedback
    {      
            [Required]
            public string Name { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            public string Phone { get; set; }

            [Required]
            public RacesCurrentYearEnum Race  { get; set; }

            [Required]
            public string Message { get; set; }        
    }
}