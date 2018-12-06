using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarathonFestival3.Models
{
    public class Order
    {
        public int OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public EnumTShirt TShirtSize { get; set; }
        public decimal TotalAmount { get; set; }
        public string EmailAddress { get; set; }
        public string RaceId { get; set; }


    }
}