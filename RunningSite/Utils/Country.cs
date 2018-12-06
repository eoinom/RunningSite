using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RunningSite.Utils
{
    public class Country
    {
        public string Name { get; set; }
        public string Alpha2Code { get; set; }
        public string Alpha3Code { get; set; }
        public string NumericCode { get; set; }
        public bool Enabled { get; set; }

        public Country() { }

        public Country(string name, string alpha2Code, string alpha3Code, string numericCode, bool enabled)
        {
            Name = name;
            Alpha2Code = alpha2Code;
            Alpha3Code = alpha3Code;
            NumericCode = numericCode;
            Enabled = enabled;
        }

        public override string ToString()
        {
            //Returns "USA - United States"
            return string.Format("{0} - {1}", Alpha3Code, Name);
        }
    }


    public class CountryArray
    {
        public List<Country> countries;
        public CountryArray()
        {
            countries = new List<Country>(50);
            countries.Add(new Country("Afghanistan", "AF", "AFG", "004", false));
            countries.Add(new Country("Aland Islands", "AX", "ALA", "248", false));
            countries.Add(new Country("Albania", "AL", "ALB", "008", false));
            countries.Add(new Country("Algeria", "DZ", "DZA", "012", false));
            countries.Add(new Country("American Samoa", "AS", "ASM", "016", false));
            countries.Add(new Country("Andorra", "AD", "AND", "020", false));
            countries.Add(new Country("Angola", "AO", "AGO", "024", false));
            countries.Add(new Country("Anguilla", "AI", "AIA", "660", false));
            countries.Add(new Country("Antarctica", "AQ", "ATA", "010", false));
            countries.Add(new Country("Antigua and Barbuda", "AG", "ATG", "028", false));
            countries.Add(new Country("Argentina", "AR", "ARG", "032", false));
            countries.Add(new Country("Armenia", "AM", "ARM", "051", false));
            countries.Add(new Country("Aruba", "AW", "ABW", "533", false));
            countries.Add(new Country("Australia", "AU", "AUS", "036", false));
            countries.Add(new Country("Austria", "AT", "AUT", "040", false));
            countries.Add(new Country("Azerbaijan", "AZ", "AZE", "031", false));
            countries.Add(new Country("Bahamas", "BS", "BHS", "044", false));
            countries.Add(new Country("Bahrain", "BH", "BHR", "048", false));
            countries.Add(new Country("Bangladesh", "BD", "BGD", "050", false));
            countries.Add(new Country("Barbados", "BB", "BRB", "052", false));
            countries.Add(new Country("Belarus", "BY", "BLR", "112", false));
            countries.Add(new Country("Belgium", "BE", "BEL", "056", false));
            countries.Add(new Country("Belize", "BZ", "BLZ", "084", false));
            countries.Add(new Country("Benin", "BJ", "BEN", "204", false));
            countries.Add(new Country("Bermuda", "BM", "BMU", "060", false));
            countries.Add(new Country("Bhutan", "BT", "BTN", "064", false));
            countries.Add(new Country("Bolivia, Plurinational State of", "BO", "BOL", "068", false));
            countries.Add(new Country("Bonaire, Sint Eustatius and Saba", "BQ", "BES", "535", false));
            countries.Add(new Country("Bosnia and Herzegovina", "BA", "BIH", "070", false));
            countries.Add(new Country("Botswana", "BW", "BWA", "072", false));
            countries.Add(new Country("Bouvet Island", "BV", "BVT", "074", false));
            countries.Add(new Country("Brazil", "BR", "BRA", "076", false));
            countries.Add(new Country("British Indian Ocean Territory", "IO", "IOT", "086", false));
            countries.Add(new Country("Brunei Darussalam", "BN", "BRN", "096", false));
            countries.Add(new Country("Bulgaria", "BG", "BGR", "100", false));
            countries.Add(new Country("Burkina Faso", "BF", "BFA", "854", false));
            countries.Add(new Country("Burundi", "BI", "BDI", "108", false));
            countries.Add(new Country("Cambodia", "KH", "KHM", "116", false));
            countries.Add(new Country("Cameroon", "CM", "CMR", "120", false));
            countries.Add(new Country("Canada", "CA", "CAN", "124", true));
            countries.Add(new Country("Cape Verde", "CV", "CPV", "132", false));
            countries.Add(new Country("Cayman Islands", "KY", "CYM", "136", false));
            countries.Add(new Country("Central African Republic", "CF", "CAF", "140", false));
            countries.Add(new Country("Chad", "TD", "TCD", "148", false));
            countries.Add(new Country("Chile", "CL", "CHL", "152", false));
            countries.Add(new Country("China", "CN", "CHN", "156", false));
            countries.Add(new Country("Christmas Island", "CX", "CXR", "162", false));
            countries.Add(new Country("Cocos (Keeling) Islands", "CC", "CCK", "166", false));
            countries.Add(new Country("Colombia", "CO", "COL", "170", false));
            countries.Add(new Country("Comoros", "KM", "COM", "174", false));
            countries.Add(new Country("Congo", "CG", "COG", "178", false));
            countries.Add(new Country("Congo, the Democratic Republic of the", "CD", "COD", "180", false));
            countries.Add(new Country("Cook Islands", "CK", "COK", "184", false));
            countries.Add(new Country("Costa Rica", "CR", "CRI", "188", false));
            countries.Add(new Country("Cote d'Ivoire", "CI", "CIV", "384", false));
            countries.Add(new Country("Croatia", "HR", "HRV", "191", false));
            countries.Add(new Country("Cuba", "CU", "CUB", "192", false));
            countries.Add(new Country("Curacao", "CW", "CUW", "531", false));
            countries.Add(new Country("Cyprus", "CY", "CYP", "196", false));
            countries.Add(new Country("Czech Republic", "CZ", "CZE", "203", false));
            countries.Add(new Country("Denmark", "DK", "DNK", "208", false));
            countries.Add(new Country("Djibouti", "DJ", "DJI", "262", false));
            countries.Add(new Country("Dominica", "DM", "DMA", "212", false));
            countries.Add(new Country("Dominican Republic", "DO", "DOM", "214", false));
            countries.Add(new Country("Ecuador", "EC", "ECU", "218", false));
            countries.Add(new Country("Egypt", "EG", "EGY", "818", false));
            countries.Add(new Country("El Salvador", "SV", "SLV", "222", false));
            countries.Add(new Country("Equatorial Guinea", "GQ", "GNQ", "226", false));
            countries.Add(new Country("Eritrea", "ER", "ERI", "232", false));
            countries.Add(new Country("Estonia", "EE", "EST", "233", false));
            countries.Add(new Country("Ethiopia", "ET", "ETH", "231", false));
            countries.Add(new Country("Falkland Islands (Malvinas)", "FK", "FLK", "238", false));
            countries.Add(new Country("Faroe Islands", "FO", "FRO", "234", false));
            countries.Add(new Country("Fiji", "FJ", "FJI", "242", false));
            countries.Add(new Country("Finland", "FI", "FIN", "246", false));
            countries.Add(new Country("France", "FR", "FRA", "250", false));
            countries.Add(new Country("French Guiana", "GF", "GUF", "254", false));
            countries.Add(new Country("French Polynesia", "PF", "PYF", "258", false));
            countries.Add(new Country("French Southern Territories", "TF", "ATF", "260", false));
            countries.Add(new Country("Gabon", "GA", "GAB", "266", false));
            countries.Add(new Country("Gambia", "GM", "GMB", "270", false));
            countries.Add(new Country("Georgia", "GE", "GEO", "268", false));
            countries.Add(new Country("Germany", "DE", "DEU", "276", false));
            countries.Add(new Country("Ghana", "GH", "GHA", "288", false));
            countries.Add(new Country("Gibraltar", "GI", "GIB", "292", false));
            countries.Add(new Country("Greece", "GR", "GRC", "300", false));
            countries.Add(new Country("Greenland", "GL", "GRL", "304", false));
            countries.Add(new Country("Grenada", "GD", "GRD", "308", false));
            countries.Add(new Country("Guadeloupe", "GP", "GLP", "312", false));
            countries.Add(new Country("Guam", "GU", "GUM", "316", false));
            countries.Add(new Country("Guatemala", "GT", "GTM", "320", false));
            countries.Add(new Country("Guernsey", "GG", "GGY", "831", false));
            countries.Add(new Country("Guinea", "GN", "GIN", "324", false));
            countries.Add(new Country("Guinea-Bissau", "GW", "GNB", "624", false));
            countries.Add(new Country("Guyana", "GY", "GUY", "328", false));
            countries.Add(new Country("Haiti", "HT", "HTI", "332", false));
            countries.Add(new Country("Heard Island and McDonald Islands", "HM", "HMD", "334", false));
            countries.Add(new Country("Holy See (Vatican City State)", "VA", "VAT", "336", false));
            countries.Add(new Country("Honduras", "HN", "HND", "340", false));
            countries.Add(new Country("Hong Kong", "HK", "HKG", "344", false));
            countries.Add(new Country("Hungary", "HU", "HUN", "348", false));
            countries.Add(new Country("Iceland", "IS", "ISL", "352", false));
            countries.Add(new Country("India", "IN", "IND", "356", false));
            countries.Add(new Country("Indonesia", "ID", "IDN", "360", false));
            countries.Add(new Country("Iran, Islamic Republic of", "IR", "IRN", "364", false));
            countries.Add(new Country("Iraq", "IQ", "IRQ", "368", false));
            countries.Add(new Country("Ireland", "IE", "IRL", "372", false));
            countries.Add(new Country("Isle of Man", "IM", "IMN", "833", false));
            countries.Add(new Country("Israel", "IL", "ISR", "376", false));
            countries.Add(new Country("Italy", "IT", "ITA", "380", false));
            countries.Add(new Country("Jamaica", "JM", "JAM", "388", false));
            countries.Add(new Country("Japan", "JP", "JPN", "392", false));
            countries.Add(new Country("Jersey", "JE", "JEY", "832", false));
            countries.Add(new Country("Jordan", "JO", "JOR", "400", false));
            countries.Add(new Country("Kazakhstan", "KZ", "KAZ", "398", false));
            countries.Add(new Country("Kenya", "KE", "KEN", "404", false));
            countries.Add(new Country("Kiribati", "KI", "KIR", "296", false));
            countries.Add(new Country("Korea, Democratic People's Republic of", "KP", "PRK", "408", false));
            countries.Add(new Country("Korea, Republic of", "KR", "KOR", "410", false));
            countries.Add(new Country("Kuwait", "KW", "KWT", "414", false));
            countries.Add(new Country("Kyrgyzstan", "KG", "KGZ", "417", false));
            countries.Add(new Country("Lao People's Democratic Republic", "LA", "LAO", "418", false));
            countries.Add(new Country("Latvia", "LV", "LVA", "428", false));
            countries.Add(new Country("Lebanon", "LB", "LBN", "422", false));
            countries.Add(new Country("Lesotho", "LS", "LSO", "426", false));
            countries.Add(new Country("Liberia", "LR", "LBR", "430", false));
            countries.Add(new Country("Libya", "LY", "LBY", "434", false));
            countries.Add(new Country("Liechtenstein", "LI", "LIE", "438", false));
            countries.Add(new Country("Lithuania", "LT", "LTU", "440", false));
            countries.Add(new Country("Luxembourg", "LU", "LUX", "442", false));
            countries.Add(new Country("Macao", "MO", "MAC", "446", false));
            countries.Add(new Country("Macedonia, the former Yugoslav Republic of", "MK", "MKD", "807", false));
            countries.Add(new Country("Madagascar", "MG", "MDG", "450", false));
            countries.Add(new Country("Malawi", "MW", "MWI", "454", false));
            countries.Add(new Country("Malaysia", "MY", "MYS", "458", false));
            countries.Add(new Country("Maldives", "MV", "MDV", "462", false));
            countries.Add(new Country("Mali", "ML", "MLI", "466", false));
            countries.Add(new Country("Malta", "MT", "MLT", "470", false));
            countries.Add(new Country("Marshall Islands", "MH", "MHL", "584", false));
            countries.Add(new Country("Martinique", "MQ", "MTQ", "474", false));
            countries.Add(new Country("Mauritania", "MR", "MRT", "478", false));
            countries.Add(new Country("Mauritius", "MU", "MUS", "480", false));
            countries.Add(new Country("Mayotte", "YT", "MYT", "175", false));
            countries.Add(new Country("Mexico", "MX", "MEX", "484", false));
            countries.Add(new Country("Micronesia, Federated States of", "FM", "FSM", "583", false));
            countries.Add(new Country("Moldova, Republic of", "MD", "MDA", "498", false));
            countries.Add(new Country("Monaco", "MC", "MCO", "492", false));
            countries.Add(new Country("Mongolia", "MN", "MNG", "496", false));
            countries.Add(new Country("Montenegro", "ME", "MNE", "499", false));
            countries.Add(new Country("Montserrat", "MS", "MSR", "500", false));
            countries.Add(new Country("Morocco", "MA", "MAR", "504", false));
            countries.Add(new Country("Mozambique", "MZ", "MOZ", "508", false));
            countries.Add(new Country("Myanmar", "MM", "MMR", "104", false));
            countries.Add(new Country("Namibia", "NA", "NAM", "516", false));
            countries.Add(new Country("Nauru", "NR", "NRU", "520", false));
            countries.Add(new Country("Nepal", "NP", "NPL", "524", false));
            countries.Add(new Country("Netherlands", "NL", "NLD", "528", false));
            countries.Add(new Country("New Caledonia", "NC", "NCL", "540", false));
            countries.Add(new Country("New Zealand", "NZ", "NZL", "554", false));
            countries.Add(new Country("Nicaragua", "NI", "NIC", "558", false));
            countries.Add(new Country("Niger", "NE", "NER", "562", false));
            countries.Add(new Country("Nigeria", "NG", "NGA", "566", false));
            countries.Add(new Country("Niue", "NU", "NIU", "570", false));
            countries.Add(new Country("Norfolk Island", "NF", "NFK", "574", false));
            countries.Add(new Country("Northern Mariana Islands", "MP", "MNP", "580", false));
            countries.Add(new Country("Norway", "NO", "NOR", "578", false));
            countries.Add(new Country("Oman", "OM", "OMN", "512", false));
            countries.Add(new Country("Pakistan", "PK", "PAK", "586", false));
            countries.Add(new Country("Palau", "PW", "PLW", "585", false));
            countries.Add(new Country("Palestine, State of", "PS", "PSE", "275", false));
            countries.Add(new Country("Panama", "PA", "PAN", "591", false));
            countries.Add(new Country("Papua New Guinea", "PG", "PNG", "598", false));
            countries.Add(new Country("Paraguay", "PY", "PRY", "600", false));
            countries.Add(new Country("Peru", "PE", "PER", "604", false));
            countries.Add(new Country("Philippines", "PH", "PHL", "608", false));
            countries.Add(new Country("Pitcairn", "PN", "PCN", "612", false));
            countries.Add(new Country("Poland", "PL", "POL", "616", false));
            countries.Add(new Country("Portugal", "PT", "PRT", "620", false));
            countries.Add(new Country("Puerto Rico", "PR", "PRI", "630", false));
            countries.Add(new Country("Qatar", "QA", "QAT", "634", false));
            countries.Add(new Country("Reunion", "RE", "REU", "638", false));
            countries.Add(new Country("Romania", "RO", "ROU", "642", false));
            countries.Add(new Country("Russian Federation", "RU", "RUS", "643", false));
            countries.Add(new Country("Rwanda", "RW", "RWA", "646", false));
            countries.Add(new Country("Saint BarthÃ©lemy", "BL", "BLM", "652", false));
            countries.Add(new Country("Saint Helena, Ascension and Tristan da Cunha", "SH", "SHN", "654", false));
            countries.Add(new Country("Saint Kitts and Nevis", "KN", "KNA", "659", false));
            countries.Add(new Country("Saint Lucia", "LC", "LCA", "662", false));
            countries.Add(new Country("Saint Martin (French part)", "MF", "MAF", "663", false));
            countries.Add(new Country("Saint Pierre and Miquelon", "PM", "SPM", "666", false));
            countries.Add(new Country("Saint Vincent and the Grenadines", "VC", "VCT", "670", false));
            countries.Add(new Country("Samoa", "WS", "WSM", "882", false));
            countries.Add(new Country("San Marino", "SM", "SMR", "674", false));
            countries.Add(new Country("Sao Tome and Principe", "ST", "STP", "678", false));
            countries.Add(new Country("Saudi Arabia", "SA", "SAU", "682", false));
            countries.Add(new Country("Senegal", "SN", "SEN", "686", false));
            countries.Add(new Country("Serbia", "RS", "SRB", "688", false));
            countries.Add(new Country("Seychelles", "SC", "SYC", "690", false));
            countries.Add(new Country("Sierra Leone", "SL", "SLE", "694", false));
            countries.Add(new Country("Singapore", "SG", "SGP", "702", false));
            countries.Add(new Country("Sint Maarten (Dutch part)", "SX", "SXM", "534", false));
            countries.Add(new Country("Slovakia", "SK", "SVK", "703", false));
            countries.Add(new Country("Slovenia", "SI", "SVN", "705", false));
            countries.Add(new Country("Solomon Islands", "SB", "SLB", "090", false));
            countries.Add(new Country("Somalia", "SO", "SOM", "706", false));
            countries.Add(new Country("South Africa", "ZA", "ZAF", "710", false));
            countries.Add(new Country("South Georgia and the South Sandwich Islands", "GS", "SGS", "239", false));
            countries.Add(new Country("South Sudan", "SS", "SSD", "728", false));
            countries.Add(new Country("Spain", "ES", "ESP", "724", false));
            countries.Add(new Country("Sri Lanka", "LK", "LKA", "144", false));
            countries.Add(new Country("Sudan", "SD", "SDN", "729", false));
            countries.Add(new Country("Suriname", "SR", "SUR", "740", false));
            countries.Add(new Country("Svalbard and Jan Mayen", "SJ", "SJM", "744", false));
            countries.Add(new Country("Swaziland", "SZ", "SWZ", "748", false));
            countries.Add(new Country("Sweden", "SE", "SWE", "752", false));
            countries.Add(new Country("Switzerland", "CH", "CHE", "756", false));
            countries.Add(new Country("Syrian Arab Republic", "SY", "SYR", "760", false));
            countries.Add(new Country("Taiwan, Province of China", "TW", "TWN", "158", false));
            countries.Add(new Country("Tajikistan", "TJ", "TJK", "762", false));
            countries.Add(new Country("Tanzania, United Republic of", "TZ", "TZA", "834", false));
            countries.Add(new Country("Thailand", "TH", "THA", "764", false));
            countries.Add(new Country("Timor-Leste", "TL", "TLS", "626", false));
            countries.Add(new Country("Togo", "TG", "TGO", "768", false));
            countries.Add(new Country("Tokelau", "TK", "TKL", "772", false));
            countries.Add(new Country("Tonga", "TO", "TON", "776", false));
            countries.Add(new Country("Trinidad and Tobago", "TT", "TTO", "780", false));
            countries.Add(new Country("Tunisia", "TN", "TUN", "788", false));
            countries.Add(new Country("Turkey", "TR", "TUR", "792", false));
            countries.Add(new Country("Turkmenistan", "TM", "TKM", "795", false));
            countries.Add(new Country("Turks and Caicos Islands", "TC", "TCA", "796", false));
            countries.Add(new Country("Tuvalu", "TV", "TUV", "798", false));
            countries.Add(new Country("Uganda", "UG", "UGA", "800", false));
            countries.Add(new Country("Ukraine", "UA", "UKR", "804", false));
            countries.Add(new Country("United Arab Emirates", "AE", "ARE", "784", false));
            countries.Add(new Country("United Kingdom", "GB", "GBR", "826", false));
            countries.Add(new Country("United States", "US", "USA", "840", true));
            countries.Add(new Country("United States Minor Outlying Islands", "UM", "UMI", "581", false));
            countries.Add(new Country("Uruguay", "UY", "URY", "858", false));
            countries.Add(new Country("Uzbekistan", "UZ", "UZB", "860", false));
            countries.Add(new Country("Vanuatu", "VU", "VUT", "548", false));
            countries.Add(new Country("Venezuela, Bolivarian Republic of", "VE", "VEN", "862", false));
            countries.Add(new Country("Viet Nam", "VN", "VNM", "704", false));
            countries.Add(new Country("Virgin Islands, British", "VG", "VGB", "092", false));
            countries.Add(new Country("Virgin Islands, U.S.", "VI", "VIR", "850", false));
            countries.Add(new Country("Wallis and Futuna", "WF", "WLF", "876", false));
            countries.Add(new Country("Western Sahara", "EH", "ESH", "732", false));
            countries.Add(new Country("Yemen", "YE", "YEM", "887", false));
            countries.Add(new Country("Zambia", "ZM", "ZMB", "894", false));
            countries.Add(new Country("Zimbabwe", "ZW", "ZWE", "716", false));
        }

        /// <summary>
        /// List of 3 digit abbreviated country codes
        /// </summary>
        /// <returns></returns>
        public string[] Alpha3Codes()
        {
            List<string> abbrevList = new List<string>(countries.Count);
            foreach (var country in countries)
            {
                if (country.Enabled)
                    abbrevList.Add(country.Alpha3Code);
            }
            return abbrevList.ToArray();
        }

        /// <summary>
        /// List of 2 digit abbreviated country codes
        /// </summary>
        /// <returns></returns>
        public string[] Alpha2Codes()
        {
            List<string> abbrevList = new List<string>(countries.Count);
            foreach (var country in countries)
            {
                if (country.Enabled)
                    abbrevList.Add(country.Alpha2Code);
            }
            return abbrevList.ToArray();
        }

        /// <summary>
        /// List of Country names
        /// </summary>
        /// <returns></returns>
        public string[] Names()
        {
            List<string> nameList = new List<string>(countries.Count);
            foreach (var country in countries)
            {
                if (country.Enabled)
                    nameList.Add(country.Name);
            }
            return nameList.ToArray();
        }

        /// <summary>
        /// List of Countries
        /// </summary>
        /// <returns></returns>
        public Country[] Countries()
        {
            return countries.Where(c => c.Enabled == true).ToArray();
        }
    }
}