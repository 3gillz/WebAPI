using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingMasterWebAPI.Models.DTO
{
    public class FoodProgramDateDTO
    {
        public int FPDID { get; set; }
        public int customer_CID { get; set; }
        public int foodProgram_FPMID { get; set; }
        public DateTime date { get; set; }
    }
}