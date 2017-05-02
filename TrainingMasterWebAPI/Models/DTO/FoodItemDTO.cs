using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingMasterWebAPI.Models.DTO
{
    public class FoodItemDTO
    {
        public int FIID { get; set; }
        public string name { get; set; }
        public int kcal { get; set; }
        public decimal fat { get; set; }
        public decimal saturatedFat { get; set; }
        public decimal unsaturatedFat { get; set; }
        public decimal colestrol { get; set; }
        public decimal carbohydrate { get; set; }
        public decimal addedSugar { get; set; }
        public decimal fiber { get; set; }
        public decimal water { get; set; }
        public decimal protein { get; set; }
        public bool suppliment { get; set; }
        public int trainer_TRID { get; set; }


    }
}