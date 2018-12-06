using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RunningSite.Models
{
    public enum Gender
    {
        Male,
        Female
    }

    public enum Tshirt_Sizes
    {
        Small,
        Medium,
        Large,
        XL,
        XXL
    }

    public enum RacesCurrentYear
    {
        Y2019_Family_5K,
        Y2019_10K,
        Y2019_Half_Marathon,
        Y2019_Marathon
    }

    public enum RacesPreviousYears
    {
        Y2018_Family_5K,
        Y2018_10K,
        Y2018_Half_Marathon,
        Y2018_Marathon,
        Y2017_Family_5K,
        Y2017_10K,
        Y2017_Half_Marathon,
        Y2017_Marathon,
        Y2016_Family_5K,
        Y2016_10K,
        Y2016_Half_Marathon,
        Y2016_Marathon
    }

    public enum StartGroup
    {
        Marathon_A_Group,
        Marathon_B_Group,
        Marathon_C_Group
    }

}