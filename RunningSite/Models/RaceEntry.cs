using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using RunningSite.Utils;

namespace RunningSite.Models
{
    public class RaceEntry
    {
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
        public Tshirt_Sizes TshirtSize { get; set; }

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
        public StartGroup StartGroup { get; set; }

        [Required]
        public int BibNo { get; set; }

    }
}