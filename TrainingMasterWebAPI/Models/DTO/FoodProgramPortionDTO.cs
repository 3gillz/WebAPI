using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingMasterWebAPI.Models.DTO
{
    public class FoodProgramPortionDTO
    {
        public int foodPortion_FPID { get; set; } 
        public int foodProgram_FPMID { get; set; }
        public int weekDay { get; set; }
        public int timeOfDay { get; set; }
    }
}