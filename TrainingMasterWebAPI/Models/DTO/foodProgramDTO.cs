using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingMasterWebAPI.Models.DTO
{
    public class foodProgramDTO
    {
        public int FPMID { get; set; }
        public int foodPortion_FPID { get; set; }
        public int trainer_TRID { get; set; }
    }
}