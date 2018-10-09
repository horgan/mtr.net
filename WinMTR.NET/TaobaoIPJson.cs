using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinMTR.NET
{

    public class IPLocationRecord
    {

        public string country { get; set; }

        public string country_id { get; set; }

        public string area { get; set; }

        public string area_id { get; set; }

        public string region { get; set; }

        public string region_id { get; set; }

        public string city { get; set; }

        public string city_id { get; set; }

        public string county { get; set; }

        public string county_id { get; set; }

        public string isp { get; set; }

        public string isp_id { get; set; }

        public string ip { get; set; }
    }


    public class TaobaoIPJson
    {
        public int code { get; set; }

        public IPLocationRecord data { get; set; }

    }
}
