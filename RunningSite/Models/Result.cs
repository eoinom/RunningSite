using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace RunningSite.Models
{
    public class Result
    {
        [DisplayName("Race ID")]
        public string RaceId { get; set; }

        [DisplayName("Bib No.")]
        public int BibNo { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Finish Place")]
        public int FinishPlace { get; set; }
        
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm\\:ss}", ApplyFormatInEditMode = true)]
        [DisplayName("Finish Time")]
        public TimeSpan FinishTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm\\:ss}", ApplyFormatInEditMode = true)]
        [DisplayName("Chip Time")]
        public TimeSpan ChipTime { get; set; }

        [EmailAddress]
        [DisplayName("Email")]
        public string Email { get; set; }
    }

    public class Results
    {
        public IEnumerable<Result> ResultList_IEnumerable { get; set; }

        public List<Result> ResultList = new List<Result>();

        public void Add(Result item)
        {
            ResultList.Add(item);
        }

    }
}