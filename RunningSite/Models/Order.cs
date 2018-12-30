using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using RunningSite.Utils;

namespace RunningSite.Models
{
    public class Order
    {
        [DisplayName("Order No.")]
        public int OrderNo { get; set; }

        [DisplayName("Order Date")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        [DisplayName("Order Amount")]
        public decimal TotalAmount { get; set; }

        [DisplayName("Address Line 1")]
        [Required]
        public string AddressLine1 { get; set; }

        [DisplayName("Address Line 2")]
        public string AddressLine2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [DataType(DataType.PostalCode)]
        public string PostCode { get; set; }

        [DisplayName("T-Shirt Size")]
        [Required]
        public TshirtSizesEnum TshirtSize { get; set; }

        public string Mobile { get; set; }

        [DisplayName("Contact Name")]
        [Required]
        public string EmergencyContactName { get; set; }

        [DisplayName("Contact Number")]
        [Required]
        public string EmergencyContactNumber { get; set; }

        [DisplayName("Medical Details")]
        [DataType(DataType.MultilineText)]
        public string MedicalDetails { get; set; }

        [Required]
        public RacesCurrentYearEnum RaceId { get; set; }
        
        [Required]
        [DisplayName("Terms and Conditions")]
        [EnforceTrue(ErrorMessage = @"Error Message")]
        public bool AgreeTermsAndConditions { get; set; }

        public bool OrderMedalInsert { get; set; }

        [Required]
        public StartGroupEnum StartGroup { get; set; }

        public int BibNo { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string PayPalReference { get; set; }
    }
}