using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingMasterWebAPI.Models.DTO
{
    public class MeasurmentMMDTO
    {
        public int MMMID { get; set; }
        public int customer_CID { get; set; }
        public DateTime date { get; set; }
        public decimal chest { get; set; }
        public decimal abdominal { get; set; }
        public decimal thigh { get; set; }
        public decimal tricep { get; set; }
        public decimal subscapular { get; set; }
        public decimal suprailiac { get; set; }
        public decimal axilliary { get; set; }
        public decimal bmi { get; set; }
        public decimal lbm { get; set; }
        public decimal fatPercentage { get; set; }
        public decimal kg { get; set; }
    }
}