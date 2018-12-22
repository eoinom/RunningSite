using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace RunningSite.Models
{
    public class Result
    {
        [DisplayName("Race ID")]
        public string RaceId { get; set; }

        [DisplayName("Bib No.")]
        public int BibNo { get; set; }

        public string Name { get; set; }

        public int FinishPlace { get; set; }
        
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm\:ss}")]
        //[DisplayFormat(DataFormatString = "{0:hh\\:mm\\:ss}")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm\\:ss}", ApplyFormatInEditMode = true)]
        public TimeSpan FinishTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm\\:ss}", ApplyFormatInEditMode = true)]
        public TimeSpan ChipTime { get; set; }        
    }

    public class Results
    {
        //public List<Result> ResultList { get; set; }
        public IEnumerable<Result> ResultList { get; set; }
    }
}