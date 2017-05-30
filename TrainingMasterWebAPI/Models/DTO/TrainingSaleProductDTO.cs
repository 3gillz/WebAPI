using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingMasterWebAPI.Models.DTO
{
    public class TrainingSaleProductDTO
    {
        public int price { get; set; }
        public int duration { get; set; }
        public int trainingSale_TSID { get; set; }
        public int product_PID { get; set; }
        public DateTime endDate { get; set; }
    }
}