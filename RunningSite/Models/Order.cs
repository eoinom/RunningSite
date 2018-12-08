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
        public Country Country { get; set; }

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
        public string EmergencyContactNo { get; set; }

        [DisplayName("Medical Details")]
        [DataType(DataType.MultilineText)]
        public string MedicalDetails { get; set; }

        [Required]
        public string RaceId { get; set; }

        [Required]
        public bool AgreeRaceDisclaimer { get; set; }

        [Required]
        public bool AgreeTermsAndConditions { get; set; }

        [Required]
        public bool OrderMedalInsert { get; set; }

        [Required]
        public StartGroupEnum StartGroup { get; set; }

        [Required]
        public int BibNo { get; set; }

        [DisplayName("Card Type")]
        public CreditCardTypesEnum CC_Type { get; set; }

        [DataType(DataType.CreditCard)]
        public string CC_Number { get; set; }

        [DisplayName("First Name")]
        public string CC_Holder_FirstName { get; set; }

        [DisplayName("Last Name")]
        public string CC_Holder_LastName { get; set; }

        [DisplayName("Month")]
        public string CC_ExpDate_Month { get; set; }

        [DisplayName("Year")]
        public string CC_ExpDate_Year { get; set; }

        [DisplayName("Security Code")]
        public string CC_SecCode { get; set; }
    }
}