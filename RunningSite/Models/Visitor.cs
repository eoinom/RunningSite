using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MarathonFestival3.Models
{
    public class Visitor
    {
        
        public string EmailAddress { get; set; }
        
        public string Password { get; set; }
      
        public string FirstName { get; set; }
     
        public string LastName { get; set; }
     
        public DateTime DateOfBirth { get; set; }
       
        public string Address1 { get; set; }

        public string Address2 { get; set; }
       
        public string Town_City { get; set; }

        public string County { get; set; }
     
        public string Country { get; set; }

        public string CreditCard { get; set; }
        public string CC_SecCode { get; set; }
        public string CC_Holder_FirstName { get; set; }
        public string CC_Holder_LastName { get; set; }
        public string CC_ExpDate { get; set; }
    }
}