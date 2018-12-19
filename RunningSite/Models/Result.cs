using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RunningSite.Models
{

    //public List<Result> Results { get; set; }

    public class Result
    {
        public string RaceId { get; set; }
        public int BibNo { get; set; }
        public string Name { get; set; }
        public int FinishPlace { get; set; }

        [DataType(DataType.Time)]
        public DateTime FinishTime { get; set; }

        [DataType(DataType.Time)]
        public DateTime ChipTime { get; set; }        
    }
}