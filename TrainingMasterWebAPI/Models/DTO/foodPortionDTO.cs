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
        public int foodItem_FIID { get; set; } //TODO: Þarf að laga í DB og ekki leyfa null
        public bool sunday { get; set; }
        public bool monday { get; set; }
        public bool tuesday { get; set; }
        public bool wednesday { get; set; }
        public bool thursday { get; set; }
        public bool friday { get; set; }
        public bool saturday { get; set; }
        public string timeOfDay { get; set; }
        public string className { get; set; }
        public string name { get; set; }
    }
}