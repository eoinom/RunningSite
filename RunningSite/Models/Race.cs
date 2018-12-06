using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarathonFestival3.Models
{
    public class Race
    {
        public int RaceId { get; set; }
        public DateTime RaceDate { get; set; }
        public int RaceLimit { get; set; }
        public decimal Price { get; set; }
    }
}