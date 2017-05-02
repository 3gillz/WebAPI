using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingMasterWebAPI.Models.DTO
{
    public class FoodPortionDTO
    {
        public int FPID { get; set; }
        public int quantity { get; set; }
        public short weekday { get; set; }
        public DateTime timeOfDay { get; set; }
        public int foodItem_FIID { get; set; }
    }
}