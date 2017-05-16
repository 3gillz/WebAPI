using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingMasterWebAPI.Models.DTO
{
    public class FoodProgramDTO
    {
        public int FPMID { get; set; }
        public string name { get; set; }
        public int trainer_TRID { get; set; }
    }
}