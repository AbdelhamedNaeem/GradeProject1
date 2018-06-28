using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GradeProject
{
    public class hospitals
    {
        public int hospital_id { get; set; }
        public string hospital_name { get; set; }
        public string hospital_city { get; set; }
        public string hospital_zone { get; set; }
        public string hospital_address { get; set; }
        public int hospital_phone { get; set; }
        public string hospital_link { get; set; }
        public string hospital_kind { get; set; }
        public double hospital_lat { get; set; }
        public double hospital_lng { get; set; }
    }
}