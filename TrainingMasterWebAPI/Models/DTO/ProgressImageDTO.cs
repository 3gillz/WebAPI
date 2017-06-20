using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingMasterWebAPI.Models.DTO
{
    public class ProgressImageDTO
    {
        public int PIID { get; set; }
        public DateTime date { get; set; }
        public int? customer_CID { get; set; }
        public byte[] image { get; set; }
    }
}