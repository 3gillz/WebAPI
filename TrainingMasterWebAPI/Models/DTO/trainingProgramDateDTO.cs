using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingMasterWebAPI.Models.DTO
{
    public class TrainingProgramDateDTO
    {
        public int TDID { get; set; }
        public int? customer_CID { get; set; }
        public int? trainingProgram_TPID { get; set; }
        public DateTime date { get; set; }
    }
}