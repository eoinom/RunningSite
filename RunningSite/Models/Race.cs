using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RunningSite.Models
{
    public class Race
    {
        [DisplayName("Race ID")]
        public string RaceId { get; set; }

        [DisplayName("Race Name")]
        public string RaceName { get; set; }

        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public DateTime RaceDate { get; set; }

        [DisplayName("Max Participants")]
        public int RaceLimit { get; set; }

        [DisplayName("Entry Price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}