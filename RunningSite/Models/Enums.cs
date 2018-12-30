using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace RunningSite.Models
{
    public enum GenderEnum
    {
        Male,
        Female
    }

    public enum TshirtSizesEnum
    {
        Small,
        Medium,
        Large,
        XL,
        XXL
    }

    public enum RacesCurrentYearEnum
    {
        [Description("2019 Family 5K")]
        R2019_05,
        [Description("2019 10K")]
        R2019_10,
        [Description("2019 Half Marathon")]
        R2019_21,
        [Description("2019 Marathon")]
        R2019_42
    }

    public enum RacesPreviousYearsEnum
    {
        [Description("2018 Family 5K")]
        R2018_05,
        [Description("2018 10K")]
        R2018_10,
        [Description("2018 Half Marathon")]
        R2018_21,
        [Description("2018 Marathon")]
        R2018_42,
        [Description("2017 Family 5K")]
        R2017_05,
        [Description("2017 10K")]
        R2017_10,
        [Description("2017 Half Marathon")]
        R2017_21,
        [Description("2017 Marathon")]
        R2017_42,
        [Description("2016 Family 5K")]
        R2016_05,
        [Description("2016 10K")]
        R2016_10,
        [Description("2016 Half Marathon")]
        R2016_21,
        [Description("2016 Marathon")]
        R2016_42,
    }

    public enum StartGroupEnum
    {
        [Description("A Group - Elite Runners")]
        A_Group,
        [Description("B Group - Medium to Fast Runners")]
        B_Group,
        [Description("C Group - Slow runner / walkers")]
        C_Group,

    }
    
}