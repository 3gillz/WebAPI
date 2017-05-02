using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingMasterWebAPI.Models.DTO
{
    public class MeasurmentCMDTO
    {
        public int MCMID { get; set; }
        public int customer_CID { get; set; }
        public DateTime date { get; set; }
        public decimal butt { get; set; }
        public decimal waist { get; set; }
        public decimal hip { get; set; }
        public decimal thigh { get; set; }
        public decimal armLoose { get; set; }
        public decimal armFlexed { get; set; }
        public decimal shoulders { get; set; }
        public bool performedByTrainer { get; set; }
    }
}