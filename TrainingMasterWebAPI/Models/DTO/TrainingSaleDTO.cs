using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingMasterWebAPI.Models.DTO
{
    public class TrainingSaleDTO
    {
        public int TSID { get; set; }
        public int customer_CID { get; set; }
        public int trainer_TRID { get; set; }
        public DateTime date { get; set; }
        public int paymentMethod_PMID { get; set; }
    }
}