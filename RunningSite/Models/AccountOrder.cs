using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RunningSite.Models
{
    public class AccountOrder
    {
        public Account account_model { get; set; }
        public Order order_model { get; set; }
    }
}