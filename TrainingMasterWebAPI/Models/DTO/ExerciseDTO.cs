using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingMasterWebAPI.Models.DTO
{
    public class ExerciseDTO
    {
        public int EID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string link { get; set; }
        public string type { get; set; }
    }
}