using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingMasterWebAPI.Models.DTO
{
    public class ProductDTO
    {
        public int PID { get; set; }
        public string name { get; set; }
        public int durationInDays { get; set; }
        public string description { get; set; }
        public int? trainer_TRID { get; set; }
        public bool? hidden { get; set; }
    }
}