using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace RunningSite.Models
{
    public class Festival
    {
        //internal CultureInfo ukCulture;

        public DateTime FestivalDate { get; set; }
        public int Price_5K { get; set; }
        public int Price_10K { get; set; }
        public int Price_HalfMarathon { get; set; }
        public int Price_Marathon { get; set; }
        public int Price_MedalInsert { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
    }
}